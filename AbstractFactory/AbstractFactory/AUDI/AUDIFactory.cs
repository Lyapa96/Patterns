using AbstractFactory.BMW;

namespace AbstractFactory.AUDI
{
    public class AUDIFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new AUDIBody();
        }

        public IBumper CreateBumper()
        {
            return new AUDIBumper();
        }

        public IEngine CreatEngine()
        {
            return new AUDIEngine();
        }

        public IHeadlights CreateHeadlights()
        {
            return new AUDIHeadlights();
        }

        public class AUDIBody : IBody
        {
            public string Name => "кузов от AUDI";
        }

        public class AUDIBumper : IBumper
        {
            public string Name => "бампер от AUDI";
        }

        public class AUDIEngine : IEngine
        {
            public string Name => "двигатель от AUDI";
        }


        public class AUDIHeadlights : IHeadlights
        {
            public string Name => "фары от AUDI";
        }
    }
}