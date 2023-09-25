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
#### `Arduino 및 모듈`
  - Arduino D1 wifi
  - RFID-RC522
  - 능동부저

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




## 6. 트러블 슈팅
### 6.1. 윈폼UI 멀티 스레드 처리
- Windows Forms는 단일 스레드 모델을 사용하며, UI 컨트롤에 대한 변경은 UI 스레드에서만 안전하게 수행해야 함. 이 코드에서는 UI 업데이트를 수행하기 위해 Invoke를 사용.
- https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/2.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EA%B3%A0%EA%B0%9D/kioskkkk.cs


### 6.2. 원격 DB 구축
- 내부망을 사용하는 환경에서 원격 DB를 구축하기 위해 RDS 서비스를 구매하여 사용.
- https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/logs.php
- https://aws.amazon.com/ko/rds/



</br>



## 6. 회고 
- HTTP통신 GET과 POST 메서드 활용: https://esoog.tistory.com/entry/get-post-%EB%B0%A9%EC%8B%9D
- PHP mysql 연동과 시큐리티 사용: https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/update.php
- C# TCP/IP 통신과 데이터 스트림 사용: https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/3.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%95%8C%EB%A6%BC%ED%8C%90/Form1.cs
- C# 스레드에 관한 고찰: https://esoog.tistory.com/entry/C-%EC%8A%A4%EB%A0%88%EB%93%9CThread
