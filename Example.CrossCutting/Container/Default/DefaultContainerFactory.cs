namespace Example.CrossCutting.Container.Default
{
    internal class DefaultContainerFactory : ContainerFactory
    {
        protected override IContainer CreateContainer()
        {
            return new DefaultContainer();
        }
    }
}
