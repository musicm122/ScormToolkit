using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScormLogic.Data
{
    public static class TestData
    {
        public static readonly string CourseListXml = @"<courselist> 
                                          <course id=""test321"" title=""Photoshop Example -- Competency"" versions=""-1"" registrations=""2"" > 
                                            <tags> 
                                              <tag>test1</tag> 
                                              <tag>test2</tag> 
                                            <tags> 
                                          </course> 
                                          <course id=""course321"" title=""Another Test Course"" versions=""-1"" registrations=""5"" > 
                                            <tags></tags> 
                                          </course> 
                                    </courselist>";
    }
}
