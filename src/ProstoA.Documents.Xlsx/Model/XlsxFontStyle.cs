﻿using System;

namespace ProstoA.Documents.Xlsx.Model {
    [Flags]
    public enum XlsxFontStyle {
        None = 0,
        Italic = 1,
        Bold = 2,
        Underline = 4
    }
}