using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            IDataTransformer service = new DataTransformer(config);
            //далее идут декораторы 
            //и тут лучше использовать chain of responsibility или лучше fluent bilder 
            if (config.WithData)
            {
                service = new WithDataReportTransformer(service);
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}