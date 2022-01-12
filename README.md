# HttpRestRequest
.NET Framework 4.7.2 로 만들었으며 HttpWebRequest 통한 Http 통신 모듈이다.

## 사용방법

> 기본방법

```
string baseUri = "http://www.test.co.kr";

HttpRestRequest request = new HttpRestRequest(baseUri);

string pathAndQuery = "/list";

HttpRestResponse response = request.Execute(HttpMethod.Get, pathAndQuery, string.Empty);
```
