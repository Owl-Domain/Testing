global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using OwlDomain.Testing.Assertions;
global using MSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


global using NSubstitute;

#if DEBUG
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel, Workers = 1)]
#else
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel, Workers = 0)]
#endif
