package dmit2015.courseproject.cms.mapper;

import dmit2015.courseproject.cms.dto.SignUpDto;
import  dmit2015.courseproject.cms.dto.UserDto;
import  dmit2015.courseproject.cms.entity.User;
import org.mapstruct.Mapping;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface UserMapper {

    UserDto toUserDto(User user);

    @Mapping(target = "password", ignore = true)
    User signUpToUser(SignUpDto signUpDto);

}