<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>adminControl</title>
    <link rel="stylesheet" href="./css/adminControl.css">
</head>
<body>
    <a href="/theme/company/dbgo/main.php"><img src="./images/logo.png" alt=""></a> 

    <?php
        $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
        $user = '';
        $pw = '';
        $dbName = 'test';
        $mysqli = new mysqli($host, $user, $pw, $dbName);

        if ($mysqli) {
            $searchValue = $_POST['searching'];
            // 데이터베이스에서 정보를 가져와 출력
            $query = "SELECT * FROM member WHERE nuid LIKE '%$searchValue%'";
            $result = mysqli_query($mysqli, $query);

            // 다른 테이블과 비교하는 로직 설정
            $query2 = "SELECT * FROM logs WHERE nuid LIKE '%$searchValue%'";
            $result2 = mysqli_query($mysqli, $query2);

            if (mysqli_num_rows($result) > 0) {
                // if (mysqli_num_rows($result) > 0)
                // 조회 결과의 행의 갯수 존재 여부 판단 문법
                while ($row = mysqli_fetch_assoc($result)) {
                    $nuid = $row['nuid'];
                    $name = $row['name'];
                    $phone = $row['phone'];
                    $address = $row['address'];
                    $enroll = $row['enroll'];
                    $fix = $row['fix'];
                    $point = $row['point'];
                    $adminName = $row['adminName'];
                        
                    echo "<div class='informBox'>";
                    echo "<span class='enroll'>등록일시: $enroll</span>";
                    echo "<span class='nuid'>카드: $nuid</span>";
                    echo "<span class='name'>이름: $name</span>";
                    echo "<span class='phone'>전화번호: $phone</span>";
                    echo "<span class='address'>주소: $address</span>";
                    echo "<span class='point'>포인트: $point</span>";
                    echo "<span class='fixs'>최근 수정: $fix -- 확인자(이름): $adminName</span>";
                    echo "</div>";
                }
                echo "<div class='logsBox'>";
                while ($row2 = mysqli_fetch_assoc($result2)) {
                    // $row2 = mysqli_fetch_assoc($result2) 
                    // 한 번 부른 순간, 커서는 다음 행으로 이동.
                    $oldLogs[] = $row2['checks'];
                }
                $newestLogs = array_reverse(array_slice($oldLogs, 0, 100));                    
                foreach ($newestLogs as $logs) {
                        echo "<p class='logsCss'>접속일시: $logs</p>";
                    }
                echo "</div>";
            } else {
                echo '<script>alert("존재하지 않는 카드번호 입니다.");</script>';
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

    <div class ="fixBox">
        <h2>---------- 정보 수정(관리자) ----------</h2>
        <form method="POST" action="adminFix.php">
            <input type="hidden" name="nuid" value="<?php echo $nuid; ?>">
            <div></div>
            <label for="name">이름:</label>
            <div></div>
            <input type="text" id="name" name="name" value="<?php echo $name; ?>">
            <div></div>
            <label for="phone">전화번호:</label>
            <div></div>
            <input type="text" id="phone" name="phone" value="<?php echo $phone; ?>">
            <div></div>
            <label for="address">주소:</label>
            <div></div>
            <input type="text" id="address" name="address"  value="<?php echo $address; ?>">
            <div></div>
            <label for="point"> 포인트 추가: </label>
            <span class="curPoint">현재 포인트 <?php echo $point; ?></span>
            <div></div>
            <input type="text" id="point" name="point" value="0">
            <div></div>
            <label for="adminName" class="req"> *관리자 확인(이름) </label>
            <div></div>
            <input type="text" id="adminName" name="adminName" required>
            <div></div>
            <button type="submit">수정하기</button>
        </form>
    </div>
</body>
</html>
