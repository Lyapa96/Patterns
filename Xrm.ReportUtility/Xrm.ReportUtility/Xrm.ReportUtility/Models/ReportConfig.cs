namespace Xrm.ReportUtility.Models
{
    public class ReportConfig
    {
        public bool WithData { get; set; }

        public bool WithIndex { get; set; }
        public bool WithTotalVolume { get; set; }
        public bool WithTotalWeight { get; set; }


        public bool VolumeSum { get; set; }
        public bool WeightSum { get; set; }
        public bool CostSum { get; set; }
        public bool CountSum { get; set; }

        //третья хотелка сюда добавляем еще несколько полей
        //=> везде где нужно ставим if и обрабатываем те ситуации
        //это очень полохое проектирование
    }
}
