using System;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace Example.CrossCutting
{
    /// <summary>
    /// Helper Class for Reflection and Lambda Expression Operation
    /// </summary>
    public static class ReflectionUtil
    {
        public static PropertyInfo FindCustomProperty<T>(Type attributeType)
        {
            var property = (from p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            from a in p.GetCustomAttributes(attributeType, true)
                            select p).SingleOrDefault();

            return property;
        }

        public static MemberInfo MemberInfo(Expression propertyExpression)
        {
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member;
            }

            return null;
        }

        public static string NameWithPath<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            String path;

            if (!ReflectionUtil.TryParseNameWithPath(expression.Body, out path))
            {
                throw new ArgumentException(String.Format("Unable to parse expression '{0}'!", expression.ToString()));
            }

            return path;
        }

        public static string Name<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.Name;
        }

        public static string FullName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.DeclaringType.FullName + "." + body.Member.Name;
        }

        public static PropertyInfo Property<T>(Expression<Func<T, Object>> selector)
        {
            MemberExpression exp = null;

            if (selector.Body is UnaryExpression)
            {
                UnaryExpression UnExp = (UnaryExpression)selector.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    exp = (MemberExpression)UnExp.Operand;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else if (selector.Body is MemberExpression)
            {
                exp = (MemberExpression)selector.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return (PropertyInfo)exp.Member;
        }

        private static Expression RemoveConvert(this Expression expression)
        {
            while (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
            {
                expression = ((UnaryExpression)expression).Operand;
            }
            return expression;
        }

        private static bool TryParseNameWithPath(Expression expression, out string path)
        {
            path = null;
            Expression expression2 = expression.RemoveConvert();
            MemberExpression memberExpression = expression2 as MemberExpression;
            MethodCallExpression methodCallExpression = expression2 as MethodCallExpression;
            if (memberExpression != null)
            {
                string name = memberExpression.Member.Name;
                string text;
                if (!ReflectionUtil.TryParseNameWithPath(memberExpression.Expression, out text))
                {
                    return false;
                }
                path = ((text == null) ? name : (text + "." + name));
            }
            else if (methodCallExpression != null)
            {
                if (methodCallExpression.Method.Name == "Select" && methodCallExpression.Arguments.Count == 2)
                {
                    string text2;
                    if (!ReflectionUtil.TryParseNameWithPath(methodCallExpression.Arguments[0], out text2))
                    {
                        return false;
                    }

                    if (text2 != null)
                    {
                        LambdaExpression lambdaExpression = methodCallExpression.Arguments[1] as LambdaExpression;
                        if (lambdaExpression != null)
                        {
                            string text3;
                            if (!ReflectionUtil.TryParseNameWithPath(lambdaExpression.Body, out text3))
                            {
                                return false;
                            }

                            if (text3 != null)
                            {
                                path = text2 + "." + text3;
                                return true;
                            }
                        }
                    }
                }

                return false;
            }

            return true;
        }
    }
}
