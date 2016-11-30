using System;
using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static Dictionary<string, Func<string[], IReportService>> extensionToReportService = new Dictionary<string, Func<string[], IReportService>>()
        {
            {".txt", (args)=> new TxtReportService(args)},
            {".csv", (args)=> new CsvReportService(args)},
            {".xlsx", (args)=> new XlsxReportService(args)}
        };

        private static IReportService GetReportService(string[] args)//фабричный метод
        {
            var filename = args[0];
            //заменить if на словарь extensionToReportService, добавление новых видов отчетов облегчится
            //можно использовать паттерн приспособленец
            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }

        private static void PrintReport(Report report)
        {
            //весь этот метод можно удалить и написать заново

            if(IsIncorrectReport(report))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                //метод ниже возможно переделать в паттерн Chain of Responsibility
                var tuple = GetHeaderRow(report);
                var headerRow = tuple.Item1;
                var rowTemplate = tuple.Item2;

                Console.WriteLine(headerRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    //следующая строчка просто ужасна                
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
            }
            //вынес в отдельный метод
            PrintResult(report);
        }

        private static void PrintResult(Report report)
        {
            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine(string.Format("  {0,-20}\t{1}", reportRow.Name, reportRow.Value));
                }
            }
        }

        private static Tuple<string,string> GetHeaderRow(Report report)
        {
            //нужно избавляться от магических числел {1,12}{4,9} и названий через \t
            //допустим названия можно приделать с помощью аттрибутов к свойствам в 
            var headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество";
            var rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";

            if (report.Config.WithIndex)
            {
                headerRow = "№\t" + headerRow;
                rowTemplate = "{0}\t" + rowTemplate;
            }
            if (report.Config.WithTotalVolume)
            {
                headerRow = headerRow + "\tСуммарный объём";
                rowTemplate = rowTemplate + "\t{6,15}";
            }
            if (report.Config.WithTotalWeight)
            {
                headerRow = headerRow + "\tСуммарный вес";
                rowTemplate = rowTemplate + "\t{7,13}";
            }
            return Tuple.Create(headerRow,rowTemplate);
        }

        private static bool IsIncorrectReport(Report report)
        {
            return report.Data == null && (report.Config.WithTotalWeight || report.Config.WithIndex || report.Config.WithTotalVolume);
        }
    }
}