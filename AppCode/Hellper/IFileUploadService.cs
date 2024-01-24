using DAPPER_CURD.Models;

namespace DAPPER_CURD.AppCode.Hellper
{
    public interface IFileUploadService
    {
        AppResponse Upload(FileUploadModel request);
    }
}
