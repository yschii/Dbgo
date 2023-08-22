<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>admin_page</title>
    <link rel="stylesheet" href="./css/admin.css">
</head>
<body>
    <a href="/theme/company/dbgo/main.php"><img src="./images/logo.png" alt=""></a> 

    <div class="searchBox">
        <form method='post' action='adminControl.php'>
            <label for="searching">*상세조회(카드번호) : </label> 
            <div></div>
            <input type='text' name='searching' placeholder='cardnNmber' required>
            <!-- input 속성 중 placeholder='흐릿한 설명 포함' 
            required 입력값 있어야 실행 가능
            value='속성 표현 이름'-->
            <div></div>
            <button type="submit">조회</button>
        </form>
    </div>

    <?php
    // 서버 사이드 스크립트. html과 연동하여 동적인 웹페이지 형성.
        if("최유성" == $_POST['adminName']){
            // $_POST['포스트로 받는 값']
            // $ 는 php에서 변수 선언 키워드

            // mysql 연동 위한 host, user, password, dbName 변수 설정.
            $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
            $user = 'esoog';
            $pw = '';
            $dbName = 'test';
            $mysqli = new mysqli($host, $user, $pw, $dbName);
            // $mysqli = new mysqli($host, $user, $pw, $dbName);
            // mysql 객체 생성 문법

            if ($mysqli) {
                // mysql에 접속 되었다면,
                $query = "SELECT * FROM member";
                // "sql문법" 을 변수 설정하여 사용.
                $result = mysqli_query($mysqli, $query);
                // $result = mysqli_query($mysqli, $query);
                // mysql 쿼리 실행 결과 설정 문법

                while ($row = mysqli_fetch_assoc($result)) {
                    // while ($row = mysqli_fetch_assoc($result))
                    // 결과에서 레코드(행)를 배열형태로 계속 출력
                    $id = $row['id'];
                    // 거기서 id필드의 값을 변수 설정.
                    $nuid = $row['nuid'];
                    $name = $row['name'];
                    $phone = $row['phone'];
                    // $address = $row['address'];
                    $enroll = $row['enroll'];
                    // $fix = $row['fix'];
                    // $point = $row['point'];

                    echo "<div class='table'>";
                    echo "<span class='id'>$id</span>";
                    echo "<span class='nuid' >$nuid</span>";
                    echo "<span class='name'>$name</span>";
                    echo "<span class='phone'>$phone</span>";
                    // echo "<span class='address'>주소 : $address</span>";
                    echo "<span class='enroll'>$enroll</span>";
                    // echo "<span class='enroll'>수정 : $fix</span>";
                    // echo "<span class='enroll'>포인트 : $point</span>";
                    echo "</div>";

                    echo "<div class='title'>";
                    echo "<span>Index</span>";
                    echo "<span>Card</span>";
                    echo "<span>Name</span>";
                    echo "<span>Phone</span>";
                    echo "<span>Enroll</span>";
                    echo "</div>";
                    
                    $lastId = $id; 
                    // 마지막 순번(id) 값을 변수에 저장
                    // 결론적으로 마지막 값만 저장되어 있음.
                }

                mysqli_free_result($result); 
                // mysqli_free_result($result); 
                // 결과셋 해제
                mysqli_close($mysqli);
                // mysql 종료 문법
            } else {
                echo '<script>alert("현재 데이터베이스를 사용할 수 없습니다.");</script>';
                // 자바스크립트 사용
                echo '<script>window.location.href = "main.php";</script>';
                // 자바스크립트 페이지 이동 사용.
            exit;
            }
        }
        else{
            echo '<script>alert("관리자 계정이 아닙니다.");</script>';
            // 자바스크립트 사용
            echo '<script>window.location.href = "main.php";</script>';
            // 자바스크립트 페이지 이동 사용.
            exit;
            // php의 break같은 키워드
        }
    ?>

    <div class="lastIdBox">
        총 가입자 수 : 
        <?php echo $lastId; ?>
        <!-- html문법 내에서 php문법의 변수 등을 사용하려면,
        // <?php echo '변수' ; ?> 처럼 
        php echo 통문법을 사용해야 함. -->
    </div>

    <div class="head">Administrator Page</div>

</body>
</html>
