<?php
    // MySQL 데이터베이스 연결 설정
    $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
    $user = '';
    $pw = '';
    $dbName = 'test';
    $mysqli = new mysqli($host, $user, $pw, $dbName);

    if ($mysqli) {
        echo "MySQL 데이터베이스에 연결되었습니다!<br/>";

        $nuid = $_GET['cardNumber'];
        $checks = date("Y-m-d H:i:s");
        $date = date("Y-m-d"); // 현재 날짜를 가져옵니다.
        $hour = date("H"); // 현재 시간(0부터 23까지의 값)을 가져옵니다.
        
        // 로그 기록이 허용된 시간대를 설정합니다 (09시부터 18시까지)
        $allowedHours = range(9, 17);
        // 추가로 로그 기록이 불가능한 시간대를 설정합니다 
        $notAllowedHours = array_merge(range(0, 8), range(17, 23));

        if (in_array($hour, $allowedHours)) {
            // 해당 카드 정보가 현재 시간대에 이미 로그에 기록되었는지 확인하기 위한 SELECT 쿼리 실행
            $checkQuery = "SELECT * FROM logs WHERE nuid = '$nuid' AND checks >= '$date $hour:00:00' AND checks <= '$date $hour:59:59'";
            $checkResult = mysqli_query($mysqli, $checkQuery);
        
            // 이미 기록되어 있다면 해당 시간대에 추가 기록을 하지 않습니다.
            if (mysqli_num_rows($checkResult) > 0) {
                echo "이미 현재 시간대에 로그가 기록되었습니다. 추가 기록이 불가능합니다.";
            } else {
                $selectQuery = "SELECT * FROM member WHERE nuid = '$nuid'";
                $result = mysqli_query($mysqli, $selectQuery);
                $row = mysqli_fetch_assoc($result);
                $currentPoint = $row['point'];  

                // 증가된 포인트 계산
                $newPoint = $currentPoint + 1000;

                if (mysqli_num_rows($result) > 0) {
                    // 기존 등록된 카드만 로그 기록
                    $insertQuery = "INSERT INTO logs (nuid, checks) VALUES ('$nuid','$checks')";
                    mysqli_query($mysqli, $insertQuery);
                    $pointQuery = "UPDATE member SET point = '$newPoint' WHERE nuid = '$nuid'";
                    mysqli_query($mysqli, $pointQuery);

                    echo "데이터가 logs 테이블에 저장되었습니다.";
                } else {
                    echo "카드 정보가 member 테이블에 존재하지 않습니다. 데이터가 저장되지 않았습니다.";
                }
            }
        } else if (in_array($hour, $notAllowedHours)) {
            echo "로그 기록은 09시부터 17시 30분까지만 가능합니다.";
        }
        
        mysqli_close($mysqli);
    } else {
        echo "MySQL 데이터베이스 연결에 실패하였습니다.";
    }
?>

