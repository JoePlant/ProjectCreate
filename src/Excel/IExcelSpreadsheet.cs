﻿using System;
using AmplaTools.ProjectCreate.Excel.Reader;
using AmplaTools.ProjectCreate.Excel.Writer;

namespace AmplaTools.ProjectCreate.Excel
{
    public interface IExcelSpreadsheet : IDisposable
    {
        /// <summary>
        /// Gets or creates a new worksheet
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IWorksheet GetWorksheet(string name);

        /// <summary>
        ///     Opens a new worksheet for reading.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IWorksheetReader ReadWorksheet(string name);

        /// <summary>
        ///     Get a worksheet writer for the specified worksheet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IWorksheetWriter WriteToWorksheet(string name);

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        bool IsReadOnly { get; }
    }
}