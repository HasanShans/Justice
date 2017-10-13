using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Justice.NotariatService;

namespace Justice.Proxy
{
    public class Notariat : Justice.NotariatService.INotariatService
    {
        public AddPersonRelationInfoResult AddPersonRelationInfo(AddPersonRelationInfoReq request)
        {
            throw new NotImplementedException();
        }

        public Task<AddPersonRelationInfoResult> AddPersonRelationInfoAsync(AddPersonRelationInfoReq request)
        {
            throw new NotImplementedException();
        }

        public FullPersonListResult GetDeadPersons(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public Task<FullPersonListResult> GetDeadPersonsAsync(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public FullDocListResult GetDocumentList(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public Task<FullDocListResult> GetDocumentListAsync(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public FullDocSearchResult GetOneDocument(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public Task<FullDocSearchResult> GetOneDocumentAsync(SearchParam param)
        {
            throw new NotImplementedException();
        }

        public SearchByPinResult GetPersonByPin(SearchByPinReq request)
        {
            throw new NotImplementedException();
        }

        public Task<SearchByPinResult> GetPersonByPinAsync(SearchByPinReq request)
        {
            throw new NotImplementedException();
        }
    }
}