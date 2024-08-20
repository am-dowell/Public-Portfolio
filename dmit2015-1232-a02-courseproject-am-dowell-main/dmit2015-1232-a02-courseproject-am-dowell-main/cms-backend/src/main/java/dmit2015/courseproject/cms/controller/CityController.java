package dmit2015.courseproject.cms.controller;

import dmit2015.courseproject.cms.dto.CityDto;
import dmit2015.courseproject.cms.service.CityService;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@CrossOrigin("*")
@RestController // class is now able to handle http request
@RequestMapping("/api/cities")
@AllArgsConstructor
public class CityController {
    private CityService cityService;

    //build Add City REST API
    @PostMapping
    public ResponseEntity<CityDto> createCity(@RequestBody CityDto cityDto) {
        CityDto savedCity = cityService.createCity(cityDto);
        return new ResponseEntity<>(savedCity, HttpStatus.CREATED);
    }

    //Build Get City REST API
    @GetMapping("{id}") //binds ID to method argument
    public ResponseEntity<CityDto> getCityById(@PathVariable("id") Long cityId){
        CityDto cityDto = cityService.getCityById(cityId);
        return ResponseEntity.ok(cityDto);
    }

    //Build GetAllCities REST API
    @GetMapping
    public ResponseEntity<List<CityDto>> getAllCities () {
        List<CityDto> cities = cityService.getAllCities();
        return ResponseEntity.ok(cities);
    }

    // build updateCity RESTAPI
    @PutMapping("{id}")
    public ResponseEntity<CityDto> updateCity(@PathVariable("id") Long cityId,
                                              @RequestBody CityDto updatedCity){
        CityDto cityDto = cityService.updateCity(cityId, updatedCity);
        return ResponseEntity.ok(cityDto);
    }

    //Build DeleteCity REST API
    @DeleteMapping("{id}")
    public ResponseEntity<String> deleteCity(@PathVariable("id") Long cityId) {
        cityService.deleteCity(cityId);
        return ResponseEntity.ok("City was deleted successfully");
    }
}
