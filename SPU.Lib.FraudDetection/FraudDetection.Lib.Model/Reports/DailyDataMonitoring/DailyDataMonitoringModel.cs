// --------------------------------------------------------------------------
// <copyright file="DailyDataMonitoringModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.29">Created</change>
// </history>

namespace FD.Lib.Model.Reports.DailyDataMonitoring
{
    using System;
    using DTO;

    /// <summary>
    /// Daily Data Monitoring Model.
    /// </summary>
    [Serializable]
    public class DailyDataMonitoringModel
    {
        public DailyDataMonitoringModel(DailyDataMonitoring rawData)
        {
            Event = rawData.Event;
            EventDate = FormatDateTimeToString(rawData.EventDate);
            DataType = rawData.DataType;
            OldDate = FormatDateTimeToString(rawData.OldDate);
            NewDate = FormatDateTimeToString(rawData.NewDate);
            OldValue = FormatMonitoredData(rawData.OldValue, DataType);
            NewValue = FormatMonitoredData(rawData.NewValue, DataType);
        }

        public string Event { get; set; }

        public string EventDate { get; set; }

        public string DataType { get; set; }

        public string OldDate { get; set; }

        public string OldValue { get; set; }

        public string NewDate { get; set; }

        public string NewValue { get; set; }

        private string FormatDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm:ss");
        }

        private string FormatMonitoredData(decimal monitoredValue, string dataType)
        {
            return dataType.ToLower().Contains("turnover")
                ? string.Format("{0:#,##0.00}", monitoredValue)
                : string.Format("{0:#,##0}", monitoredValue);
        }
    }
}