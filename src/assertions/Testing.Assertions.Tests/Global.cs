global using System;
global using System.Collections.Generic;
global using System.Diagnostics.CodeAnalysis;
global using System.Threading.Tasks;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Moq;
global using OwlDomain.Testing.Assertions;
global using OwlDomain.Testing.Base;
global using MSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#if DEBUG
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel, Workers = 1)]
#else
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel, Workers = 0)]
#endif
