package dmit2015.courseproject.cms.dto;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;


//DTO is like viewmodel
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class CityDto {
    private Long id;
    private String name;
    private String stateProvince;
    private String country;
}
