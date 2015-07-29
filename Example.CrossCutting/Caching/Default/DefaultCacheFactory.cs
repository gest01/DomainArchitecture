namespace Example.CrossCutting.Caching.Default
{
    internal class DefaultCacheFactory : CacheFactory
    {
        public override ICache CreateCache()
        {
            return new DefaultCache();
        }

        protected override ICache CreateDefaultCache()
        {
            return CreateCache();
        }
    }
}
