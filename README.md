# HttpRestRequest

## 소개
.NET Framework 4.7.2 로 만들었으며 HttpWebRequest 통한 Http 통신 모듈이다.
Http 통신시 여러가지 방법이 있지만 해당 라이브러리는 HttpWebRequest 함수를 통해 만들어졌다.


## 사용설명서


> HttpRestRequest

요청을 보내기 위해서 사용하는 Class 이다.
```C#
HttpRestRequest request = new HttpRestRequest(baseUri);
```

##### Execute(HttpMethod method, string pathAndQuery, string data)
request 요청하는 함수이다.
POST 요청인경우 Json Data 담아서 보낼 경우 data 매개변수에 보내면 된다.
```
JObject jObject = new JObejct()
{
    ...    
};

request.Execute(HttpMethod.Post, "", jObject.ToString());
```


> HttpRestResponse

응답을 받기위해 사용하는 Class 이다.
```C#
HttpRestResponse response = request.Execute(HttpMethod.Get, pathAndQuery, string.Empty);
```

> Header

Request 요청시 header를 설정시 사용한다.


##### Add Header
```
Header header = new Header();
```
기본 속성
* Accept
* Connection
* ContentLength
* ContentType
* Date
* Expect
* Host
* IfModifiedSince
* Referer
* TransferEncoding
* UserAgent
* Proxy
```
header.Accept = "application/json"
```

이 외 Header 추가시
```C#
header.Add([name], [value]);
```

header 설정을 마친후 request.header 에 넘겨준다.
```
request.header = header;
```

