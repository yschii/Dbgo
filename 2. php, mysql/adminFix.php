<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>adminFix</title>
</head>

<body>
    <?php
    $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
    $user = '';
    $pw = '';
    $dbName = 'test';
    $mysqli = new mysqli($host, $user, $pw, $dbName);

    if ($mysqli) {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            // $_SERVER['REQUEST_METHOD']
            // 현재 요청 http 메소드를 받는 php내장 변수
            // php에서 '===' =를 3개 사용하면,
            // 타입과 값을 함께 비교하는 보다 정밀한 검사기능 수행.
            // 결론은, 코드의 의도와 요청의 유효성을 보장하기
            // 위해 사용.
            $nuid = $_POST['nuid'];
            $name = $_POST['name'];
            $phone = $_POST['phone'];
            $address = $_POST['address'];
            $point = $_POST['point']; // 추가할 포인트
            $adminName = $_POST['adminName'];

            // 기존 포인트 값을 가져오기
            $query = "SELECT point FROM member WHERE nuid = '$nuid'";
            $result = mysqli_query($mysqli, $query);
            $row = mysqli_fetch_assoc($result);
            $currentPoint = $row['point'];
            // 증가된 포인트 계산
            $newPoint = $currentPoint + $point;

            // 데이터베이스 업데이트 쿼리 실행
            $fix = date("Y-m-d H:i:s");
            // date("Y-m-d H:i:s") 현재 시간 php함수
            $query = "UPDATE member SET name = '$name', phone = '$phone', address = '$address', point = '$newPoint' , fix = '$fix', adminName = '$adminName' WHERE nuid = '$nuid'";
            $result = mysqli_query($mysqli, $query);
            if ($result) {
                echo '<script>alert("데이터가 성공적으로 업데이트 되었습니다.");</script>';
                echo '<script>window.location.href = "main.php";</script>';
                exit;
            } else {
                echo '<script>alert("데이터 업데이트에 실패했습니다.");</script>';
                echo '<script>window.location.href = "main.php";</script>';
                exit;
            }

            mysqli_close($mysqli);
        } else {
            echo '<script>alert("잘못된 요청 방식입니다.");</script>';
            echo '<script>window.location.href = "main.php";</script>';
            exit;
        }
    } else {
        echo '<script>alert("현재 데이터베이스를 사용할 수 없습니다.");</script>';
        echo '<script>window.location.href = "main.php";</script>';
        exit;
    }
    ?>

</body>

</html>