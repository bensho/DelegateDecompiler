﻿using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace DelegateDecompiler.Tests
{
    [TestFixture]
    public class ClosuresTest : DecompilerTestsBase
    {
        const string Skip = "Compiler builds expression and delegate in case of closures in different ways";
        
        int y = 0;
        static int z = 0;

        readonly TestClass instanceTestClass = new TestClass();
        readonly static TestClass staticTestClass = new TestClass();

        [Test, Ignore(Skip)]
        public void CanUseVariableClosure()
        {
            int x = 0;
            Expression<Func<object, int>> expected = o => x;
            Func<object, int> compiled = o => x;
            Test(expected, compiled);
        } 

        [Test, Ignore(Skip)]
        public void CanUseFieldClosure()
        {
            Expression<Func<object, int>> expected = o => y;
            Func<object, int> compiled = o => y;
            Test(expected, compiled);
        }
 
        [Test]
        public void CanUseStaticFieldClosure()
        {
            Expression<Func<object, int>> expected = o => z;
            Func<object, int> compiled = o => z;
            Test(expected, compiled);
        }
 
        [Test, Ignore(Skip)]
        public void CanUseFieldAndVariableClosures()
        {
            int x = 0;
            Expression<Func<object, int>> expected = o => x + y;
            Func<object, int> compiled = o => x + y;
            Test(expected, compiled);
        } 
 
        [Test, Ignore(Skip)]
        public void CanUseFieldAndStaticFieldAndVariableClosures()
        {
            int x = 0;
            Expression<Func<object, int>> expected = o => x + y + z;
            Func<object, int> compiled = o => x + y + z;
            Test(expected, compiled);
        } 

        [Test, Ignore(Skip)]
        public void CanUseRefVariableClosure()
        {
            var x = new TestClass();
            Expression<Func<object, TestClass>> expected = o => x;
            Func<object, TestClass> compiled = o => x;
            Test(expected, compiled);
        } 

        [Test, Ignore(Skip)]
        public void CanUseRefFieldClosure()
        {
            Expression<Func<object, TestClass>> expected = o => instanceTestClass;
            Func<object, TestClass> compiled = o => instanceTestClass;
            Test(expected, compiled);
        }
 
        [Test]
        public void CanUseRefStaticFieldClosure()
        {
            Expression<Func<object, int>> expected = o => z;
            Func<object, int> compiled = o => z;
            Test(expected, compiled);
        }
 
        [Test, Ignore(Skip)]
        public void CanUseRefFieldAndVariableClosures()
        {
            var x = new TestClass();
            Expression<Func<object, string>> expected = o => "" + x + instanceTestClass;
            Func<object, string> compiled = o => "" + x + instanceTestClass;
            Test(expected, compiled);
        } 
 
        [Test, Ignore(Skip)]
        public void CanUseRefFieldAndStaticFieldAndVariableClosures()
        {
            var x = new TestClass();
            Expression<Func<object, string>> expected = o => "" + x + instanceTestClass + staticTestClass;
            Func<object, string> compiled = o => "" + x + instanceTestClass + staticTestClass;
            Test(expected, compiled);
        } 
    }
}