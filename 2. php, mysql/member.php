<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>member_page</title>
    <link rel="stylesheet" href="./css/member.css">
</head>
<body>
    <a href="/theme/company/dbgo/main.php"><img src="./images/logo.png" alt=""></a> 

    <?php
    $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
    $user = 'esoog';
    $pw = '';
    $dbName = 'test';
    $mysqli = new mysqli($host, $user, $pw, $dbName);

    if ($mysqli) {
        $cardNumber = $_POST['cardNumber'];
        $password = $_POST['password'];

        // 데이터베이스에서 카드를 확인하는 로직을 추가
        $query = "SELECT * FROM member WHERE nuid = '$cardNumber'";
        $result = mysqli_query($mysqli, $query);
        $row = mysqli_fetch_assoc($result);
        if($row>0){
            // 데이터베이스에서 저장된 해시된 비밀번호 가져오기
            $storedHash = $row['psw'];
            $reset = $row['reset'];
            if($password==$reset){
                $storedHash = password_hash($password, PASSWORD_DEFAULT);
            }
        }else{
            echo '<script>alert("아이디 정보가 없습니다.");</script>';
            // 자바스크립트 사용
            echo '<script>window.location.href = "main.php";</script>';
            // 자바스크립트 페이지 이동 사용.
            exit;
        }
        
        // password_verify($입력값, $비교할 해시화된 값) 함수는
        // 입력값을 해시화된 값과 비교해서 검증
        if (password_verify($password, $storedHash)) {
            // 초기 비밀번호를 모두 해시화 해서 공유할 수 없으니
            // 초기 비밀번호와 비교하는 로직을 최초 사용 후,
            // 업데이트 로직에서 초기 비밀번호와 함께 해시화 시켜서 변경.

            // 카드 번호가 존재하는 경우 페이지를 보여줌
            $name = $row['name'];
            $phone = $row['phone'];
            $address = $row['address'];
            $point = $row['point'];
            
            echo "<div class='informBox'>";
            echo "<span class='nuid'>카드: $cardNumber</span>";
            echo "<span class='name'>이름: $name</span>";
            echo "<span class='phone'>전화번호: $phone</span>";
            echo "<span class='address'>주소: $address</span>";
            echo "<span class='point'>포인트: $point</span>";
            echo "</div>";
            ?>

            <div class ="fixBox">
                <h2>---------- 개인정보 수정하기 ----------</h2>
                <form method="POST" action="update.php">
                    <input type="hidden" name="nuid" value="<?php echo $cardNumber; ?>">
                    <label for="name">이름:</label>
                    <div></div>
                    <input type="text" id="name" name="name" value="<?php echo $name; ?>" oninput="removeSpaces(this)" required>
                    <div></div>
                    <label for="phone">전화번호(-없이):</label>
                    <div></div>
                    <input type="text" id="phone" name="phone" value="<?php echo $phone; ?>" oninput="removeSpaces(this)" required>
                    <div></div>
                    <label for="address">주소:</label>
                    <div></div>
                    <input type="text" id="address" name="address"  value="<?php echo $address; ?>" oninput="removeSpaces(this)" required>
                    <div></div>
                    <label for="password" class="psw1">*비밀번호:</label>
                    <div></div>
                    <input type="password" id="password" name="password" oninput="removeSpaces(this)" required>
                    <div></div>
                    <label for="confirmPassword" class="psw1">*비밀번호 확인:</label>
                    <div></div>
                    <input type="password" id="confirmPassword" name="confirmPassword" oninput="removeSpaces(this)" required>
                    <!-- 비밀번호 확인 절차를 위해 2번 입력 받기 -->
                    <div></div>
                    <button type="submit">입력</button>
                </form>
            </div>
        <?php
        } else {
            echo '<script>alert("비밀번호가 다릅니다.");</script>';
            // 자바스크립트 사용
            echo '<script>window.location.href = "main.php";</script>';
            // 자바스크립트 페이지 이동 사용.
            exit;
        }

        mysqli_free_result($result); // 결과셋 해제
        mysqli_close($mysqli);
    } else {
        echo '<script>alert("현재 데이터베이스를 사용할 수 업습니다.");</script>';
        // 자바스크립트 사용
        echo '<script>window.location.href = "main.php";</script>';
        // 자바스크립트 페이지 이동 사용.
        exit;
    }
    ?>

    <script>
        function removeSpaces(input) {
            // 입력 필드에서 공백 제거
            input.value = input.value.replace(/\s/g, '');
        }
    </script>

</body>
</html>
