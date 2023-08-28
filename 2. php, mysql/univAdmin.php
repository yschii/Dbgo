<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="./css/univAdmin.css">
    <title>univAdmin</title>
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
        $query2 = "SELECT logs.nuid, logs.checks, member.name, 
            DATE(logs.checks) AS log_date, HOUR(logs.checks) AS log_hour 
            FROM logs 
            INNER JOIN member ON logs.nuid = member.nuid 
            ORDER BY log_date DESC,log_hour DESC ,logs.checks ASC";
        $result2 = mysqli_query($mysqli, $query2);

        if (mysqli_num_rows($result2) > 0) {
            $last_date = null;
            $last_hour = null;
            $total_name_count = 0;

            echo "<div class='boxer'>";
            echo "<p>*로그를 활용한 프로그램 제작.
                대학교의 시간적인 틀(09~18)시 안에만 로그 기록 가능.
                또한, 출결을 위해 1시간에 한 번씩만 인식 가능케 함.
                추가적으로 출석에 따른 보상(포인트 1000점)을
                시간당 얻을 수 있게 만듦. 이를 적절히 활용하면,
                다양한 시스템으로 사용 가능.
                </p>";
            echo "<div class='exel'>"; // 테이블 시작
    
            while ($row = mysqli_fetch_assoc($result2)) {
                $nuid = $row['nuid'];
                $name = $row['name'];
                $checks = $row['checks'];
                $log_date = $row['log_date'];
                $log_hour = $row['log_hour'];

                if ($last_date !== $log_date || $last_hour !== $log_hour) {
                    if ($last_date !== null) {
                        echo "<td><b>출석 인원: {$total_name_count}</b></td>";
                        echo "</tr>";
                        echo "</table>";
                    }

                    echo "<h2>날짜: {$log_date} / {$log_hour}시</h2>";
                    echo "<table class='exel'>";
                    echo "<tr>";
                    echo "<th>Name</th>";
                    echo "<th>Checks</th>";
                    echo "</tr>";

                    $last_date = $log_date;
                    $last_hour = $log_hour;
                    $total_name_count = 0;
                }

                $total_name_count++;

                echo "<tr>";
                echo "<td>{$name}</td>";
                echo "<td>{$checks}</td>";
                echo "</tr>";
            }

            if ($last_date !== null) {
                echo "<td><b>출석 인원: {$total_name_count}</b></td>";
                echo "</tr>";
                echo "</table>";
            }

            echo "</div>";
            echo "</div>";
        } else {
            echo '<script>alert("정보가 존재하지 않습니다.");</script>';
            echo '<script>window.location.href = "main.php";</script>';
            exit;
        }

        mysqli_free_result($result2); // Result for grouped dates
        mysqli_close($mysqli);
    } else {
        echo '<script>alert("현재 데이터베이스를 사용할 수 없습니다.");</script>';
        echo '<script>window.location.href = "main.php";</script>';
        exit;
    }
    ?>

</body>

</html>