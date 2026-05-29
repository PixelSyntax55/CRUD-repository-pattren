using AutoMapper;

using lastoneapi.studu;

namespace lastoneapi.School.Controllers.DTOS
{
    public class MappingStudent : Profile
    {
        public MappingStudent() 
        {

            CreateMap<Student , ResponceStudentDto>();

            CreateMap<RequestStudentDto , Student>();

        }


    }
}
