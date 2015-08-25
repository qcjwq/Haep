namespace Haep.AutofacTest.CycleDependence
{
    public class ClassA
    {
        private readonly ClassB b;

        public ClassA(ClassB b)
        {
            this.b = b;
        }
    }
}