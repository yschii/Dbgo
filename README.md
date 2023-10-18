# :pushpin: Dbgo
>실시간 DB처리를 활용한 출결관리 시스템
</br>
>http://www.poderoser.com/theme/company/dbgo/main.php
</br>
>![image](https://github.com/yschii/Dbgo/assets/135096712/312e45d5-3b96-4962-919c-9b100e04af8a)
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
  - C++
#### `Front-end`
  - Css, JavaScript
#### `Arduino 및 모듈`
  - Arduino D1 wifi
  - RFID-RC522
  - 능동부저
#### 'etc'
  - HTTP 통신
  - TCP/IP 통신
  - Invoke/ 스레드
</br>



## 프로그램 테스트
trial 폴더에서 > 실행프로그램 테스트
<details>
<summary><b>실행화면</b></summary>
<div markdown="1">

![스크린샷 2023-10-17 231613](https://github.com/yschii/Dbgo/assets/135096712/75519f62-22cc-40a3-b354-3d935ec9a5e6)
</br>
![스크린샷 2023-10-17 231735](https://github.com/yschii/Dbgo/assets/135096712/819f6431-58af-4832-a0e2-a195dfbf3aba)
</br>
![스크린샷 2023-10-17 231803](https://github.com/yschii/Dbgo/assets/135096712/88df2250-2be1-48a9-84bd-6adbdfa1a4db)
</br>
![스크린샷 2023-10-17 231821](https://github.com/yschii/Dbgo/assets/135096712/71b18692-96db-4bfb-907e-75ebd77d2900)
</br>
![스크린샷 2023-10-17 231842](https://github.com/yschii/Dbgo/assets/135096712/80d20bbe-d90c-4392-8d09-72387bc02681)
</br>
![스크린샷 2023-10-17 231900](https://github.com/yschii/Dbgo/assets/135096712/2f041627-34e4-4287-9ca6-962504dc7e34)
</br>
![스크린샷 2023-10-17 231916](https://github.com/yschii/Dbgo/assets/135096712/6d40a7e8-eb64-4859-8506-6efec0f3c3cb)

</div>
</details>
</br>


## 3. ERD 설계(Entity Relationship Diagram)
![image](https://github.com/yschii/Dbgo/assets/135096712/3fa639a2-5f45-4031-b4fe-f6953188f9a2)
</br>


## 4. 핵심 기능
이 서비스의 핵심 기능은 웹과 아두이노 간 실시간 DB 구축 통신 입니다.
사용자는 아두이노 모듈을 통해 데이터를 입력시키기만 하면, 데이터베이스를 구축하고, 
웹에서 DB 처리 및 활용이 가능합니다.
이 단순한 기능의 흐름을 보면, 웹과 하드웨어가 어떻게 동작하는지 알 수 있습니다.  
</br>

<details>
<summary><b>핵심 기능 설명 펼치기</b></summary>
<div markdown="1">

### 4.1. 전체 흐름
![image](https://github.com/yschii/Dbgo/assets/135096712/1c501ce6-45a2-425e-b130-891fed9a3030)
* rds 사용료 부담으로 카드 테스트 키오스크는 로컬 mysql로 변경 사용
</br>



### 4.2. 아두이노 RFID모듈을 통한 카드 인식 및 http 통신으로 데이터 보내기기
![image](https://github.com/yschii/Dbgo/assets/135096712/3cbbd4e1-a9e8-4723-98cb-aa6e167942d4)
https://github.com/yschii/Dbgo/blob/main/1.%20rfid/memberCard_register/memberCard_register.ino
</br>


### 4.3. Php 서버 사이드 측에서 데이터 로직 구현 및 DB에 데이터 저장
![image](https://github.com/yschii/Dbgo/assets/135096712/856d5496-187c-497d-abd6-56d12991de57)
https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/register.php
</br>


### 4.4. Web에서 데이터 출력
![image](https://github.com/yschii/Dbgo/assets/135096712/6a8972d2-6544-494d-bb4b-c6666b758e14)
https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/admin.php
</br>


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
</br>

<details>
<summary><b>확장 기능 설명 펼치기</b></summary>
<div markdown="1">


### 5.1. TCP/IP통신 활용한 윈도우 프로그램 서버 생성
![image](https://github.com/yschii/Dbgo/assets/135096712/380a04f6-bc21-437d-9ea6-86ff407a7119)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/1.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%A3%BC%EB%B0%A9(%EC%84%9C%EB%B2%84)/MainForm.cs
</br>

### 5.2. 시리얼통신으로 아두이노와 연결. TCP/IP통신으로 윈도우 프로그램 서버와 연결. Mysql DB연동 클라이언트 생성
![image](https://github.com/yschii/Dbgo/assets/135096712/11a8ac92-8011-48a4-af09-4294f25d5bba)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/2.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EA%B3%A0%EA%B0%9D/Kiosk.cs
</br>

### 5.3. 알림판 뷰어 생성 및 데이터 출력
![image](https://github.com/yschii/Dbgo/assets/135096712/c1c4fce7-d7f4-47fc-b823-8f50be83f650)
https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/3.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%95%8C%EB%A6%BC%ED%8C%90/Notes.cs
</br>
</div>
</details>

</br>


## 6. 트러블 슈팅
### 6.1. 윈폼UI 멀티 스레드 처리
- Windows Forms는 단일 스레드 모델을 사용하며, UI 컨트롤에 대한 변경은 UI 스레드에서만 안전하게 수행해야 함. 이 코드에서는 UI 업데이트를 수행하기 위해 Invoke를 사용.
- https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/1.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%A3%BC%EB%B0%A9(%EC%84%9C%EB%B2%84)/MainForm.cs
</br>


### 6.2. 원격 DB 구축
- 내부망을 사용하는 환경에서 원격 DB를 구축하기 위해 RDS 서비스를 구매하여 사용.
- https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/logs.php
- https://aws.amazon.com/ko/rds/
</br>



## 7. 회고 
- HTTP통신 GET과 POST 메서드 활용: https://esoog.tistory.com/entry/get-post-%EB%B0%A9%EC%8B%9D
  
- PHP mysql 연동과 시큐리티 사용: https://github.com/yschii/Dbgo/blob/main/2.%20php%2C%20mysql/update.php
  
- C# TCP/IP 통신과 데이터 스트림 사용: https://github.com/yschii/Dbgo/blob/main/3.%20%ED%99%95%EC%9E%A51(%ED%8F%AC%EC%9D%B8%ED%8A%B8%20%EC%A0%9C%EB%8F%84%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC)/1.%20%ED%82%A4%EC%98%A4%EC%8A%A4%ED%81%AC%20%EC%A3%BC%EB%B0%A9(%EC%84%9C%EB%B2%84)/MainForm.cs
  
- C# 스레드에 관한 고찰: https://esoog.tistory.com/entry/C-%EC%8A%A4%EB%A0%88%EB%93%9CThread
  </br>
