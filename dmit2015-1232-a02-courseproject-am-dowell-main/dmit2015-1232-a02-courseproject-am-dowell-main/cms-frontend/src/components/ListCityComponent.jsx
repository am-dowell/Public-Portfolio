import React, { useEffect, useState} from 'react'
import { deleteCity, listCities } from '../services/CityService'
import { useNavigate} from 'react-router-dom'

const ListCityComponent = () => {
// const dummyData = [
//     {
//     "id" : 1,
//     "name" : "AbbyTown",
//     "stateProvince" : "Texas",
//     "country" : "USA"
//     },
//     {
//         "id" : 2,
//         "name" : "Isaacville",
//         "stateProvince" : "Washington",
//         "country" : "USA"
//     },
//     {
//         "id" : 3,
//         "name" : "Smallville",
//         "stateProvince" : "British Columbia",
//         "country" : "Canada"
//     }
// ]

const [cities, setCities] = useState([])
const navigator = useNavigate();

useEffect(() => {
    getAllCities();
}, [])

function getAllCities () {
    listCities().then((response) => {
        setCities(response.data)
    }).catch(error => {
        console.error(error);
    })
}

function addNewCity() {
    navigator('/add-city')
}

function updateCity (id) {
    navigator(`/edit-city/${id}`)
}

function removeCity (id) {
    console.log(id);

    deleteCity(id).then((response) => {
        getAllCities();
    }).catch(error => {
        console.error(error)
    })
}

return (
    <div className='container margin-auto'>
        <h2 className='text-center'>Cities</h2>
        <button className='btn btn-primary mb-2' onClick={addNewCity}>Create City</button>
        <table className='table table-striped table-bordered'>
            <thead>
                <tr>
                    <th>City Name</th>
                    <th>State/Province</th>
                    <th>Country</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {
                    cities.map(city =>
                    <tr key={city.id}>
                        <td>{city.name}</td>
                        <td>{city.stateProvince}</td>
                        <td>{city.country}</td>
                        <td>
                            <button className='btn btn-info' onClick={() => updateCity(city.id)}>Update</button>
                            <button className='btn btn-danger' onClick={() => removeCity(city.id)}
                            style={{marginLeft: '10px'}}>
                                Delete</button>
                        </td>
                    </tr>)
                }
            </tbody>
        </table>
    </div>
  )
}

export default ListCityComponent