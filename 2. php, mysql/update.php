<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>update_check</title>
</head>
<body>
    <?php
        $host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
        $user = '';
        $pw = '';
        $dbName = 'test';
        $mysqli = new mysqli($host, $user, $pw, $dbName);

        if ($mysqli) {
            if ($_SERVER['REQUEST_METHOD'] === 'POST') {
                // 폼에서 전달된 값 받기
                $nuid = $_POST['nuid'];
                $name = $_POST['name'];
                $phone = $_POST['phone'];
                $address = $_POST['address'];

                $password = $_POST['password'];
                $confirmPassword = $_POST['confirmPassword'];
                // 비밀번호와 비밀번호 확인 일치 여부 확인
                if ($password !== $confirmPassword) {
                    echo '<script>alert("비밀번호와 비밀번호 확인이 일치하지 않습니다.");</script>';
                    echo '<script>window.location.href = "main.php";</script>';
                    exit;
                }
                
                $hpsw = password_hash($password, PASSWORD_DEFAULT);
                // password_hash($입력값, PASSWORD_DEFAULT)
                // 입력값을 해시화 시킴.

                // 데이터베이스 업데이트 쿼리 실행
                $fix = date("Y-m-d H:i:s"); // 수정일 추가
                $query = "UPDATE member SET name = '$name', phone = '$phone', address = '$address', psw = '$hpsw', reset = '$hpsw' , fix = '$fix', adminName = '$name' WHERE nuid = '$nuid'";
                // 초기화 비번과 해시화된 비번을 통일 시켜 변경.
                // 추후 비번은 해시화된 값과 동일해야 검증 통과
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


