import React, { useEffect, useState } from 'react'
import { createCity, updateCity, getCity } from '../services/CityService'
import { useNavigate , useParams} from 'react-router-dom'

const CityComponent = () => {
  const[name, setName] = useState('')
  const [stateProvince, setStateProvince] = useState('')
  const[country, setCountry] = useState('')

  const {id} = useParams();

  const [errors, setErrors] = useState({
    name: '',
    stateProvince:'',
    country: ''
  })

  const navigator = useNavigate();

  useEffect(() => {
    if(id) {
      getCity(id).then((response) => {
        setName(response.data.name);
        setStateProvince(response.data.stateProvince);
        setCountry(response.data.country);
      }).catch(error => {
        console.error(error)
      })
    }
  }, [id]  )

  //simplified even further from a function to calling directly in the onChange listener
    // const handleName = (c) => setName(c.target.value);
    // const handleStateProvince = (c) => setStateProvince(c.target.value);
    // const handleCountry = (c) => setCountry(c.target.value); 

  function saveorUpdateCity(c){
    c.preventDefault();

    if(validateForm()) {
      const city = {name, stateProvince, country}
      console.log(city);
      if (id) {
        updateCity(id, city).then((response) => {
          console.log(response.data)
          navigator('/cities')
        }).catch (error => {
          console.error(error)
        })
      }
      else {
        createCity(city).then((response) => {
          console.log(response.data);
          navigator('/cities');
        }).catch(error => {
          console.error(error)
        })
      }
    }
}

function  validateForm() {
  let valid = true;
// ... is a SPREAD OPERATOR. converts value into ErrorsCopy
  const errorsCopy = {... errors};

  if(name.trim()) {
    errorsCopy.name = '';
  } else {
    errorsCopy.name = 'City Name is required.'
    valid = false;
  }
  if(stateProvince.trim()) {
    errorsCopy.stateProvince = '';
  }else {
    errorsCopy.stateProvince = 'State/Province is required.'
    valid = false;
  }
  if(country.trim()) {
    errorsCopy.country = '';
  }else {
    errorsCopy.country = 'Country is required.'
    valid = false;
  }
  setErrors(errorsCopy);
  return valid;
}

function pageTitle() {
  if(id) {
    return  <h2 className='text-center'>Update City</h2>
  }
  else{
    <h2 className='text-center'>Add City</h2>
  }
}

  return (
    <div className='container'>
      <br></br>
      <div className='row'>
        <div className='card col-md-6 offset-md-3 offset-md-3'>
          {
            pageTitle()
          }
          <div className='card-body'>
            <form>
              <div className='form-group mb-2'>
                <label className='form-label'>City Name</label>
                <input
                  type='text'
                  placeholder='Enter City Name'
                  name='name'
                  value={name}
                  className={`form-control ${errors.name ? 'is-invalid' : ''}`}
                  onChange={(c) => setName(c.target.value)}>
                </input>
                {errors.name && <div className='invalid-feedback'>{errors.name}</div>}
              </div>

              <div className='form-group mb-2'>
                <label className='form-label'>State/Province</label>
                <input
                  type='text'
                  placeholder='Enter State/Province'
                  name='stateProvince'
                  value={stateProvince}
                  className={`form-control ${errors.stateProvince ? 'is-invalid' : ''}`}
                  onChange={(c) => setStateProvince(c.target.value)}>
                </input>
                {errors.stateProvince && <div className='invalid-feedback'>{errors.stateProvince}</div>}
              </div>

              <div className='form-group mb-2'>
                <label className='form-label'>Country</label>
                <input
                  type='text'
                  placeholder='Enter Country'
                  name='country'
                  value={country}
                  className={`form-control ${errors.country ? 'is-invalid' : ''}`}
                  onChange={(c) => setCountry(c.target.value)}>
                </input>
                {errors.country && <div className='invalid-feedback'>{errors.country}</div>}
              </div>

              <button className='btn btn-success' onClick={saveorUpdateCity}>Save</button>

            </form>
          </div>
        </div>
      </div>
    </div>
  )
}

export default CityComponent