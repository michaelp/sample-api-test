# API testing 

[Test Jest](https://github.com/kulshekhar/ts-jest)

[Jest get started](https://jestjs.io/docs/getting-started)


https://medium.com/nerd-for-tech/testing-typescript-with-jest-290eaee9479d


https://swizec.com/blog/how-to-configure-jest-with-typescript/

https://javascript.plainenglish.io/beginners-guide-to-testing-jest-with-node-typescript-1f46a1b87dad

## Code generation

### **My personal preference**

* I have no problem with having java in my path and i value having the official codegen by swagger
    * It supports all the latest features
    * Does not generate singleton clients
    * Easily customizable 

* Step 1: **installation** 
  * Have Java in your path
  * `npm i --save-dev @openapitools/openapi-generator-cli`

* Step 2: **code generation** - add this to `package.json`
```js
"scripts": {
    "test": "jest",
    "codegen": "rimraf src/generated-sources/openapi && openapi-generator-cli generate -i ../bot.srv/bin/swagger.json -o src/generated-sources/openapi -g typescript-axios"
  }
```
* Step 3: **usage** 
```ts
import *  as API from "../../src/generated-sources/openapi";
import * as Axios from 'axios';

const configuration = new API.Configuration({
    basePath: 'http://localhost:80', // use dotenv package instead of hardcode urls
    
});
// in the case of troubleshooting
Axios.default.interceptors.request.use(request => {
    //console.log('Starting Request', JSON.stringify(request, null, 2))
    return request
  })
// in the case of troubleshooting
Axios.default.interceptors.response.use(response => {
    //console.log('Response:', JSON.stringify(response, null, 2))
    return response
  })
// the crux of all this 
const api = API.WeatherApiFactory(configuration);
test('should ', async () => {
    // use the SDKs for fun and profit
    const result = await api.getWeatherForecast();
            console.log(JSON.stringify(result.data))
});
```




### **Alternative** *If you are allergic to having Java in your path*

```sh
yarn add --dev openapi-typescript-codegen
yarn openapi --input references/swagger.json \
    --output references/codegen \
    --client axios \
    --postfix Service \
    --useOptions \
    --useUnionTypes
```

## Online validators and editors  

* [An online validator for swagger.json](https://apitools.dev/swagger-parser/online)
* [An online editor and validator](https://editor.swagger.io)