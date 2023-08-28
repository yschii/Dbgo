<?php
    // MySQL 데이터베이스 연결 설정
    $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
    $user = '';
    $pw = '';
    $dbName = 'test';
    $mysqli = new mysqli($host, $user, $pw, $dbName);

    if($mysqli){
        echo "MySQL successfully connected!<br/>";

        $nuid = $_GET['cardNumber'];
        $checks = date("Y-m-d H:i:s");

        // member 테이블에서 같은 카드 정보를 가진 행을 확인하기 위한 SELECT 쿼리 실행
        $selectQuery = "SELECT * FROM member WHERE nuid = '$nuid'";
        $result = mysqli_query($mysqli, $selectQuery);
        $row = mysqli_fetch_assoc($result);
        $currentPoint = $row['point'];  

        // 증가된 포인트 계산
        $newPoint = $currentPoint + 1000;

        if(mysqli_num_rows($result) > 0) {
            // 기존 등록된 카드만 로그 기록
            $insertQuery = "INSERT INTO logs (nuid, checks) VALUES ('$nuid','$checks')";
            mysqli_query($mysqli, $insertQuery);
            $pointQuery = "UPDATE member SET point = '$newPoint' WHERE nuid = '$nuid'";
            mysqli_query($mysqli, $pointQuery);

            echo "Data saved to logs table.";
        } else {
            echo "Card information does not exist in member table. Data not saved.";
        }
    }
    else{
        echo "MySQL could not be connected";
    }

    mysqli_close($mysqli);
?>
