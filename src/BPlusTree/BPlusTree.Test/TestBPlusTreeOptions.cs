﻿#region Copyright 2011 by Roger Knapp, Licensed under the Apache License, Version 2.0
/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion
using System;
using System.Collections.Generic;
using CSharpTest.Net.Serialization;
using NUnit.Framework;
using CSharpTest.Net.Collections;

namespace CSharpTest.Net.BPlusTree.Test
{
    [TestFixture]
    public class TestBPlusTreeOptions
    {
        [Test]
        public void TestICloneable()
        {
            ICloneable opt = new BPlusTree<int, int>.Options(PrimitiveSerializer.Int32, PrimitiveSerializer.Int32) 
            {
                SerializeInMemory = true,
                CreateFile = CreatePolicy.IfNeeded,
                BTreeOrder = 4
            };
            BPlusTree<int, int>.Options options = (BPlusTree<int, int>.Options)opt.Clone();
            
            Assert.AreEqual(true, options.SerializeInMemory);
            Assert.AreEqual(CreatePolicy.IfNeeded, options.CreateFile);
            Assert.AreEqual(4, options.MaximumChildNodes);
            Assert.AreEqual(4, options.MaximumValueNodes);
        }
    }
}
