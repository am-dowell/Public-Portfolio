package dmit2015.courseproject.cms.mapper;

import dmit2015.courseproject.cms.dto.CityDto;
import dmit2015.courseproject.cms.entity.City;

public class CityMapper {
    public static CityDto mapToCityDto(City city) {
        return new CityDto(
                city.getId(),
                city.getName(),
                city.getStateProvince(),
                city.getCountry()
        );
    }

    public static City mapToCityEntity(CityDto cityDto) {
        return new City(
                cityDto.getId(),
                cityDto.getName(),
                cityDto.getStateProvince(),
                cityDto.getCountry()
        );
    }
}
