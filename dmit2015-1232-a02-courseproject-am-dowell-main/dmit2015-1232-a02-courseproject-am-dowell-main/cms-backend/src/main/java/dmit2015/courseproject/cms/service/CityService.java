package dmit2015.courseproject.cms.service;

import dmit2015.courseproject.cms.dto.CityDto;
import dmit2015.courseproject.cms.entity.City;

import java.util.List;

public interface CityService {

    CityDto createCity(CityDto cityDto);

    CityDto getCityById(Long cityId);

    List<CityDto> getAllCities();

    CityDto updateCity(Long cityId, CityDto updatedCity);

    void deleteCity(Long cityId);
}
