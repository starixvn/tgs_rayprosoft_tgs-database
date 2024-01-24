// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0290:使用主要建構函式")]
[assembly: SuppressMessage("Style", "IDE0300:簡化集合初始化")]
[assembly: SuppressMessage("Style", "IDE0028:簡化集合初始化")]
[assembly: SuppressMessage("Style", "IDE0301:簡化集合初始化")]
[assembly: SuppressMessage("Style", "IDE0305:簡化集合初始化")]
[assembly: SuppressMessage("Performance", "CA1869:快取並重新使用 'JsonSerializerOptions' 執行個體", Justification = "<暫止>", Scope = "member", Target = "~M:TGS.Core.Infrastructures.Extensions.ObjectExtensions.ToJson(System.Object,System.Boolean)~System.String")]
[assembly: SuppressMessage("Maintainability", "CA1510:使用 ArgumentNullException 擲回協助程式")]
[assembly: SuppressMessage("Interoperability", "SYSLIB1054:使用 'LibraryImportAttribute' 而非 'DllImportAttribute' 在編譯時間產生 P/Invoke 封送處理程式碼")]
