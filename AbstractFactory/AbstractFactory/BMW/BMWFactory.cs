namespace AbstractFactory.BMW
{
    public class BMWFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new BMWBody();
        }

        public IBumper CreateBumper()
        {
            return new BMWBumper();
        }

        public IEngine CreatEngine()
        {
            return new BMWEngine();
        }

        public IHeadlights CreateHeadlights()
        {
            return new BMWHeadlights();
        }


        public class BMWBody : IBody
        {
            public string Name => "кузов от BMW";
        }

        public class BMWBumper : IBumper
        {
            public string Name => "бампер от BMW";
        }

        public class BMWEngine : IEngine
        {
            public string Name => "двигатель от BMW";
        }


        public class BMWHeadlights : IHeadlights
        {
            public string Name => "фары от BMW";
        }


    }
}