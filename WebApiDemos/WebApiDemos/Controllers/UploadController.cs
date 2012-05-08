using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiDemos.Controllers
{
    public class UploadController : ApiController
    {
        const string PATH = "c:/uploads/";
        public async Task<IList<string>> Post()
        {
            List<string> result = new List<string>();

            if (Request.Content.IsMimeMultipartContent())
            {
                try
                {
                    MultipartFormDataStreamProvider stream =
                        new MultipartFormDataStreamProvider(PATH);

                    IEnumerable<HttpContent> bodyparts =
                        await Request.Content.ReadAsMultipartAsync(stream);

                    IDictionary<string, string> bodyPartFiles = 
                        stream.BodyPartFileNames;

                    bodyPartFiles
                        .Select(i => { return i.Value; })
                        .ToList()
                            .ForEach(x => result.Add(x));
                }
                catch (Exception e)
                {
                    //log etc
                }
            }
            return result;
        }
    }
}
