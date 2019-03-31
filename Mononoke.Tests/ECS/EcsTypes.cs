namespace Mononoke.Tests.ECS
{
    public class EcsTypes
    {
        public class A { }
        public class B : I1 { }
        public class C { }
        
        public class A1 : A { }
        public class A2 : A1 { }
        
        public class B1 : B { }
        
        public interface I1 { }
        
        public interface I2 { }
    }
}