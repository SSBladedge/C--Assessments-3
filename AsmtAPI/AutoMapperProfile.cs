namespace AsmtAPI;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Student, GetStudentResponseDTO>();
        CreateMap<AddStudentRequestDTO, Student>();
        CreateMap<UpdateStudentRequestDTO, Student>();
    }
}