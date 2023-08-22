<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dbgo</title>
    <link rel="stylesheet" href="./css/main.css">
</head>
<body>
    <a href="/theme/company/dbgo/main.php"><img src="./images/logo.png" alt=""></a> 
    <div class="forms1">
        <form id="jsForm1" method="POST" action="member.php">
            <!-- 자바스크립트를 활용하기위해 일반적으로 id값 활용 -->
            <label for="cardNumber">카드번호:</label> 
            <div></div>
            <input type="text" id="cardNumber" name="cardNumber" oninput="removeSpaces(this)" required>
            <div></div>
            <label for="password">비밀번호(초기 비밀번호 0000):</label> 
            <div></div>
            <input type="password" id="password" name="password" oninput="removeSpaces(this)" required>
            <!-- 비밀번호 폼은 input타입의 password 존재. -->
            <div></div>
            <button type="submit">입장</button>
        </form>
    </div>
    
    <div class="forms2">
        <form id="jsForm2" method="POST" action="admin.php">
            <label for="adminName">*관리자 모드(최유성):</label> 
            <div></div>
            <input type="text" id="adminName" name="adminName" oninput="removeSpaces(this)" required>
            <div></div>
            <button type="submit">입장</button>
        </form>
    </div>

    <div class="forms3">
        <form action="univAdmin.php">
            <label for="univAdmin">*출결관리 시스템(Trial):</label> 
            <button type="submit">입장</button>
        </form>
    </div>

    <script>
        document.getElementById("jsForm1").addEventListener("submit", function() {
            setTimeout(clearForm, 0); 
            // document.getElementById("id명").addEventListener()를 사용하여 
            // 'submit' 등록, 실행함수 function(){}
            // 포스트 요청 후에 입력란을 초기화하기 위해 setTimeout 사용
            // setTimeout(설정 함수, 지연시간); 
        });
        document.getElementById("jsForm2").addEventListener("submit", function() {
            setTimeout(clearForm, 0); 
            // 포스트 요청 후에 입력란을 초기화하기 위해 setTimeout 사용
        });

        // function(){} 함수 설정 부분
        function clearForm() {
            document.getElementById("cardNumber").value = "";
            // 엘리먼트의 .value 값을~
            document.getElementById("password").value = "";
            document.getElementById("adminName").value = "";
        }

        function removeSpaces(input) {
            // 입력 필드에서 공백 제거
            input.value = input.value.replace(/\s/g, '');
        }
    </script>
</body>
</html>
