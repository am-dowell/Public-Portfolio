package dmit2015.courseproject.cms.service.impl;

import dmit2015.courseproject.cms.dto.CityDto;
import dmit2015.courseproject.cms.entity.City;
import dmit2015.courseproject.cms.exception.ResourceNotFoundException;
import dmit2015.courseproject.cms.mapper.CityMapper;
import dmit2015.courseproject.cms.repository.CityRepository;
import dmit2015.courseproject.cms.service.CityService;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;


@Service // tells the spring container to create the spring bean for CityServiceImpl
//IMPL stands for Implementation
@AllArgsConstructor
public class CityServiceImpl implements CityService {

    private CityRepository cityRepository;

    @Override
    public CityDto createCity(CityDto cityDto) {
        //Convert CityDto into CityEntity - entity gets stored to database.
        City city = CityMapper.mapToCityEntity(cityDto);
        City savedCity = cityRepository.save(city);

        return CityMapper.mapToCityDto(savedCity);
    }

    @Override
    public CityDto getCityById(Long cityId) {
        City city = cityRepository.findById(cityId)
                .orElseThrow(() ->
                        new ResourceNotFoundException("City with ID of [" + cityId + "] does not exist"));
        return CityMapper.mapToCityDto(city);
    }

    @Override
    public List<CityDto> getAllCities() {
        List<City> cities = cityRepository.findAll();
        return cities.stream().map((city) ->
                CityMapper.mapToCityDto(city))
                .collect(Collectors.toList());
    }

    @Override
    public CityDto updateCity(Long cityId, CityDto updatedCity) {
        City city =  cityRepository.findById(cityId).orElseThrow(() ->
                new ResourceNotFoundException("City with ID of [" + cityId + "] does not exist"));

        city.setName(updatedCity.getName());
        city.setStateProvince(updatedCity.getStateProvince());
        city.setCountry(updatedCity.getCountry());

        City updatedCityObj = cityRepository.save(city);

        return CityMapper.mapToCityDto(updatedCityObj);
    }

    @Override
    public void deleteCity(Long cityId) {
        City city = cityRepository.findById(cityId).orElseThrow(() ->
                new ResourceNotFoundException("City with ID of [" + cityId + "] does not exist")
        );
        cityRepository.deleteById(cityId);
    }
}
