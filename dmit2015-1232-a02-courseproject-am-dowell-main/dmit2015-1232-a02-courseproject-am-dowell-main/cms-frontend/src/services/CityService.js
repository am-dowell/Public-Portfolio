import axios from "axios";

//Const calls rest api
const REST_API_BASE_URL = 'http://localhost:8080/api/cities'

//Authentication
axios.defaults.headers.post['Content-Type'] = 'application/json';

export const getAuthToken = () => {
    return window.localStorage.getItem('auth_token');
};

export const setAuthHeader = (token) => {
    if (token !== null) {
      window.localStorage.setItem("auth_token", token);
    } else {
      window.localStorage.removeItem("auth_token");
    }
};

export const request = (method, url, data) => {

    let headers = {};
    if (getAuthToken() !== null && getAuthToken() !== "null") {
        headers = {'Authorization': `Bearer ${getAuthToken()}`};
    }

    return axios({
        method: method,
        url: url,
        headers: headers,
        data: data});
};

//Calls GetAllCities
export const listCities = () => axios.get(REST_API_BASE_URL);

export const createCity = (city) => axios.post(REST_API_BASE_URL, city);

export const getCity = (cityId) => axios.get(REST_API_BASE_URL + '/' + cityId);

export const updateCity = (cityId, city) => axios.put(REST_API_BASE_URL + '/' + cityId, city);

export const deleteCity = (cityId) => axios.delete(REST_API_BASE_URL + '/' + cityId);

export const authRequest = (method, url, data) => {
    return axios({
        method: method,
        url: url,
        data: data
    });
}