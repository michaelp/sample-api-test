import 'jest';
import { add }  from '../../src/utils';
import *  as API from "../../src/generated-sources/openapi";
import * as Axios from 'axios';

const configuration = new API.Configuration({
    basePath: 'http://localhost:80',
    
});
//Axios.default.interceptors
Axios.default.interceptors.request.use(request => {
    //console.log('Starting Request', JSON.stringify(request, null, 2))
    return request
  })
  
Axios.default.interceptors.response.use(response => {
    //console.log('Response:', JSON.stringify(response, null, 2))
    return response
  })
const api = API.WeatherApiFactory(configuration);
test('should ', async () => {
    const result = await api.getWeatherForecast();
            console.log(JSON.stringify(result.data))
});
describe("sample test suite 1", () => {
   
    beforeAll(() => {
       
    });
    afterAll(() => {
       
        
    });
    describe('Sample Fixture 1', () => {
        it('should do this and that 1', async () => {
            const result = await api.getWeatherForecast();
            console.log(JSON.stringify(result.headers))

        })
        
    });
});