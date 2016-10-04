using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieObjectTest.Models;
using Xunit;

namespace MovieObjectTest.Tests
{
    public class ArgoClassTest
    {
        [Fact]
        public void GetMovieTitleTest()
        {
            var result = movieJsonArgo.Title;
            Assert.Equal("argo", result);
        }
    }
}
