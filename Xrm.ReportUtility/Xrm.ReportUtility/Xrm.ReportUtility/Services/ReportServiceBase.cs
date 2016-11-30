using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private readonly string[] _args;

        protected ReportServiceBase(string[] args)
        {
            _args = args;
        }

        public Report CreateReport()//это паттерн шаблонный метод, наследники переопределяют поведение GetDataRows
        {
            var config = ParseConfig();
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = _args[0];
            var text = File.ReadAllText(fileName);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        private ReportConfig ParseConfig()
        {
            //для второго задания
            CheckRequiredFields();

            //это выглядит очень сранно, но видимо по другму сделать не получается
            return new ReportConfig
            {
                WithData = _args.Contains("-data"),

                WithIndex = _args.Contains("-withIndex"),
                WithTotalVolume = _args.Contains("-withTotalVolume"),
                WithTotalWeight = _args.Contains("-withTotalWeight"),

                VolumeSum = _args.Contains("-volumeSum"),
                WeightSum = _args.Contains("-weightSum"),
                CostSum = _args.Contains("-costSum"),
                CountSum = _args.Contains("-countSum")
            };
        }

        private void CheckRequiredFields()
        {
            List<string> requiredField = new List<string>()
            {
                "-volumeSum",
                "-weightSum",
                "-costSum",
                "-countSum"
            };
            var countFields = requiredField.Count(field => _args.Contains(field));
            if (countFields == 0) throw new ArgumentException("обязательнo указание хотя бы одного из флагов volumeSum, weightSum, costSum, countSum");
        }

        protected abstract DataRow[] GetDataRows(string text);
    }
}
