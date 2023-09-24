# :pushpin: Dbgo
>실시간 DB처리를 활용한 출결관리 시스템
>http://www.poderoser.com/theme/company/dbgo/main.php
</br>

## :pushpin: Contact
- 이메일: winstonys516@naver.com
- 블로그: https://esoog.tistory.com
- 깃헙: https://github.com/yschii

</br>

## 1. 제작 기간 & 참여 인원
- 2023년 7월~8월
- 개인 프로젝트

</br>

## 2. 사용 기술
#### `Back-end`
  - C#
  - .Net Framework 4.7.2
  - Php 5.6
  - MySQL 5.1.73
#### `Front-end`
  - Css, JavaScript

</br>

## 3. ERD 설계
![image](https://github.com/yschii/Dbgo/assets/135096712/3fa639a2-5f45-4031-b4fe-f6953188f9a2)



## 4. 핵심 기능
이 서비스의 핵심 기능은 웹과 아두이노 간 실시간 DB 구축 통신 입니다.
사용자는 아두이노 모듈을 통해 데이터를 입력시키기만 하면, 데이터베이스를 구축하고, 
웹에서 DB 처리 및 활용이 가능합니다.
이 단순한 기능의 흐름을 보면, 웹과 하드웨어가 어떻게 동작하는지 알 수 있습니다.  

<details>
<summary><b>핵심 기능 설명 펼치기</b></summary>
<div markdown="1">

### 4.1. 전체 흐름
![image](https://github.com/yschii/Dbgo/assets/135096712/1c501ce6-45a2-425e-b130-891fed9a3030)


### 4.2. 아두이노 RFID모듈을 통한 카드 인식 및 http 통신으로 데이터 보내기기
![image](https://github.com/yschii/Dbgo/assets/135096712/e2e20e66-99e8-4717-9d8f-c1cbef86f6ae)
https://github.com/yschii/Dbgo/blob/main/1.%20rfid/memberCard_register/memberCard_register.ino


### 4.3. Php 서버 사이드 측에서 데이터 로직 구현 및 DB에 데이터 저장
![image](https://github.com/yschii/Dbgo/assets/135096712/856d5496-187c-497d-abd6-56d12991de57)
https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/register.php


### 4.4. Web에서 데이터 출력
![image](https://github.com/yschii/Dbgo/assets/135096712/6a8972d2-6544-494d-bb4b-c6666b758e14)
https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/admin.php


### 4.5. 실시간 태그 인식으로 DB 구축
![image](https://github.com/yschii/Dbgo/assets/135096712/18889fb5-de78-45a5-9986-bf198cbd6769)
</div>
</details>

</br>



## 5. 확장 기능
확장 기능은 웹과 윈도우 프로그램 그리고 아두이노 간 통신 연결 입니다.
사용자는 아두이노 모듈을 통해 데이터를 입력시키기만 하면, 데이터베이스를 구축하고, 
웹과 윈도우프로그램에서 DB 처리 및 활용이 가능합니다.
이로서 웹과 프로그램 그리고 하드웨어가 어떻게 동작하는지 알 수 있습니다.  

<details>
<summary><b>확장 기능 설명 펼치기</b></summary>
<div markdown="1">


### 5.1. TCP/IP통신 활용한 윈도우 프로그램 서버 생성
![image](https://github.com/yschii/Dbgo/assets/135096712/15b59ec3-3973-4c70-bc25-4a524ba13308)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/1.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%A3%BC%EB%B0%A9(%EC%84%9C%EB%B2%84)/Form1.cs


### 5.2. 시리얼통신으로 아두이노와 연결. TCP/IP통신으로 윈도우 프로그램 서버와 연결. Mysql DB연동 클라이언트 생성
![image](https://github.com/yschii/Dbgo/assets/135096712/3ba0dd06-4148-447e-bd77-71835a4eb37c)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/2.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EA%B3%A0%EA%B0%9D/kioskkkk.cs


### 5.3. 알림판 뷰어 생성 및 데이터 출력
![image](https://github.com/yschii/Dbgo/assets/135096712/c21903bd-8d59-4879-9f0a-92009270fb3d)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/3.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%95%8C%EB%A6%BC%ED%8C%90/Form1.cs

</div>
</details>

</br>




## 5. 핵심 트러블 슈팅
### 5.1. 방향성
- 원래는 RFID 카드 시스템으로 포인트 시스템을 만들어, 키오스크를 제작하고자 프로젝트를 시작하게 되었습니다.
하지만, 윈도우 프로그램만 사용하는 것 보다 범용적으로 확장시켜 사용할 수 있게 하기 위해
웹까지 접목 시키게 되었습니다.

- 하지만 [무한스크롤, 페이징 혹은 “더보기” 버튼? 어떤 걸 써야할까](https://cyberx.tistory.com/82) 라는 글을 읽고 무한 스크롤의 단점들을 알게 되었고,  
다양한 기준(카테고리, 사용자, 등록일, 인기도)의 게시물 필터 기능을 넣어서 이를 보완하고자 했습니다.

- 그런데 게시물이 필터링 된 상태에서 무한 스크롤이 동작하면,  
필터링 된 게시물들만 DB에 요청해야 하기 때문에 아래의 **기존 코드** 처럼 각 필터별로 다른 Query를 날려야 했습니다.

<details>
<summary><b>코드</b></summary>
<div markdown="1">

~~~java

~~~

</div>
</details>


</br>

## 6. 그 외 트러블 슈팅
<details>
<summary>npm run dev 실행 오류</summary>
<div markdown="1">

- Webpack-dev-server 버전을 3.0.0으로 다운그레이드로 해결
- `$ npm install —save-dev webpack-dev-server@3.0.0`

</div>
</details>

<details>
<summary>vue-devtools 크롬익스텐션 인식 오류 문제</summary>
<div markdown="1">
  
  - main.js 파일에 `Vue.config.devtools = true` 추가로 해결
  - [https://github.com/vuejs/vue-devtools/issues/190](https://github.com/vuejs/vue-devtools/issues/190)
  
</div>
</details>

<details>
<summary>ElementUI input 박스에서 `v-on:keyup.enter="메소드명"`이 정상 작동 안하는 문제</summary>
<div markdown="1">
  
  - `v-on:keyup.enter.native=""` 와 같이 .native 추가로 해결
  
</div>
</details>

<details>
<summary> Post 목록 출력시에 Member 객체 출력 에러 </summary>
<div markdown="1">
  
  - 에러 메세지(500에러)
    - No serializer found for class org.hibernate.proxy.pojo.javassist.JavassistLazyInitializer and no properties discovered to create BeanSerializer (to avoid exception, disable SerializationConfig.SerializationFeature.FAIL_ON_EMPTY_BEANS)
  - 해결
    - Post 엔티티에 @ManyToOne 연관관계 매핑을 LAZY 옵션에서 기본(EAGER)옵션으로 수정
  
</div>
</details>
    
<details>
<summary> 프로젝트를 git init으로 생성 후 발생하는 npm run dev/build 오류 문제 </summary>
<div markdown="1">
  
  ```jsx
    $ npm run dev
    npm ERR! path C:\Users\integer\IdeaProjects\pilot\package.json
    npm ERR! code ENOENT
    npm ERR! errno -4058
    npm ERR! syscall open
    npm ERR! enoent ENOENT: no such file or directory, open 'C:\Users\integer\IdeaProjects\pilot\package.json'
    npm ERR! enoent This is related to npm not being able to find a file.
    npm ERR! enoent

    npm ERR! A complete log of this run can be found in:
    npm ERR!     C:\Users\integer\AppData\Roaming\npm-cache\_logs\2019-02-25T01_23_19_131Z-debug.log
  ```
  
  - 단순히 npm run dev/build 명령을 입력한 경로가 문제였다.
   
</div>
</details>    

<details>
<summary> 태그 선택후 등록하기 누를 때 `object references an unsaved transient instance - save the transient instance before flushing` 오류</summary>
<div markdown="1">
  
  - Post 엔티티의 @ManyToMany에 영속성 전이(cascade=CascadeType.ALL) 추가
    - JPA에서 Entity를 저장할 때 연관된 모든 Entity는 영속상태여야 한다.
    - CascadeType.PERSIST 옵션으로 부모와 자식 Enitity를 한 번에 영속화할 수 있다.
    - 참고
        - [https://stackoverflow.com/questions/2302802/object-references-an-unsaved-transient-instance-save-the-transient-instance-be/10680218](https://stackoverflow.com/questions/2302802/object-references-an-unsaved-transient-instance-save-the-transient-instance-be/10680218)
   
</div>
</details>    

<details>
<summary> JSON: Infinite recursion (StackOverflowError)</summary>
<div markdown="1">
  
  - @JsonIgnoreProperties 사용으로 해결
    - 참고
        - [http://springquay.blogspot.com/2016/01/new-approach-to-solve-json-recursive.html](http://springquay.blogspot.com/2016/01/new-approach-to-solve-json-recursive.html)
        - [https://stackoverflow.com/questions/3325387/infinite-recursion-with-jackson-json-and-hibernate-jpa-issue](https://stackoverflow.com/questions/3325387/infinite-recursion-with-jackson-json-and-hibernate-jpa-issue)
        
</div>
</details>  
    
<details>
<summary> H2 접속문제</summary>
<div markdown="1">
  
  - H2의 JDBC URL이 jdbc:h2:~/test 으로 되어있으면 jdbc:h2:mem:testdb 으로 변경해서 접속해야 한다.
        
</div>
</details> 
    
<details>
<summary> 컨텐츠수정 모달창에서 태그 셀렉트박스 드랍다운이 뒤쪽에 보이는 문제</summary>
<div markdown="1">
  
   - ElementUI의 Global Config에 옵션 추가하면 해결
     - main.js 파일에 `Vue.us(ElementUI, { zIndex: 9999 });` 옵션 추가(9999 이하면 안됌)
   - 참고
     - [https://element.eleme.io/#/en-US/component/quickstart#global-config](https://element.eleme.io/#/en-US/component/quickstart#global-config)
        
</div>
</details> 

<details>
<summary> HTTP delete Request시 개발자도구의 XHR(XMLHttpRequest )에서 delete요청이 2번씩 찍히는 이유</summary>
<div markdown="1">
  
  - When you try to send a XMLHttpRequest to a different domain than the page is hosted, you are violating the same-origin policy. However, this situation became somewhat common, many technics are introduced. CORS is one of them.

        In short, server that you are sending the DELETE request allows cross domain requests. In the process, there should be a **preflight** call and that is the **HTTP OPTION** call.

        So, you are having two responses for the **OPTION** and **DELETE** call.

        see [MDN page for CORS](https://developer.mozilla.org/en-US/docs/Web/HTTP/Access_control_CORS).

    - 출처 : [https://stackoverflow.com/questions/35808655/why-do-i-get-back-2-responses-of-200-and-204-when-using-an-ajax-call-to-delete-o](https://stackoverflow.com/questions/35808655/why-do-i-get-back-2-responses-of-200-and-204-when-using-an-ajax-call-to-delete-o)
        
</div>
</details> 

<details>
<summary> 이미지 파싱 시 og:image 경로가 달라서 제대로 파싱이 안되는 경우</summary>
<div markdown="1">
  
  - UserAgent 설정으로 해결
        - [https://www.javacodeexamples.com/jsoup-set-user-agent-example/760](https://www.javacodeexamples.com/jsoup-set-user-agent-example/760)
        - [http://www.useragentstring.com/](http://www.useragentstring.com/)
        
</div>
</details> 
    
<details>
<summary> 구글 로그인으로 로그인한 사용자의 정보를 가져오는 방법이 스프링 2.0대 버전에서 달라진 것</summary>
<div markdown="1">
  
  - 1.5대 버전에서는 Controller의 인자로 Principal을 넘기면 principal.getName(0에서 바로 꺼내서 쓸 수 있었는데, 2.0대 버전에서는 principal.getName()의 경우 principal 객체.toString()을 반환한다.
    - 1.5대 버전에서 principal을 사용하는 경우
    - 아래와 같이 사용했다면,

    ```jsx
    @RequestMapping("/sso/user")
    @SuppressWarnings("unchecked")
    public Map<String, String> user(Principal principal) {
        if (principal != null) {
            OAuth2Authentication oAuth2Authentication = (OAuth2Authentication) principal;
            Authentication authentication = oAuth2Authentication.getUserAuthentication();
            Map<String, String> details = new LinkedHashMap<>();
            details = (Map<String, String>) authentication.getDetails();
            logger.info("details = " + details);  // id, email, name, link etc.
            Map<String, String> map = new LinkedHashMap<>();
            map.put("email", details.get("email"));
            return map;
        }
        return null;
    }
    ```

    - 2.0대 버전에서는
    - 아래와 같이 principal 객체의 내용을 꺼내 쓸 수 있다.

    ```jsx
    UsernamePasswordAuthenticationToken token =
                    (UsernamePasswordAuthenticationToken) SecurityContextHolder
                            .getContext().getAuthentication();
            Map<String, Object> map = (Map<String, Object>) token.getPrincipal();

            String email = String.valueOf(map.get("email"));
            post.setMember(memberRepository.findByEmail(email));
    ```
        
</div>
</details> 
    
<details>
<summary> 랭킹 동점자 처리 문제</summary>
<div markdown="1">
  
  - PageRequest의 Sort부분에서 properties를 "rankPoint"를 주고 "likeCnt"를 줘서 댓글수보다 좋아요수가 우선순위 갖도록 설정.
  - 좋아요 수도 똑같다면..........
        
</div>
</details> 
    
</br>

## 6. 회고 / 느낀점
>프로젝트 개발 회고 글: https://zuminternet.github.io/ZUM-Pilot-integer/
