<?php
	// MySQL 데이터베이스 연결 설정
	$host = 'mysql.caf3ckeqkfac.ap-southeast-2.rds.amazonaws.com';
	$user = '';
	$pw = '';
	$dbName = 'test';
	$mysqli = new mysqli($host, $user, $pw, $dbName);

	if($mysqli){
		echo "MySQL successfully connected!<br/>";

		$nuid = $_POST['cardNumber'];
		$enroll = date("Y-m-d H:i:s");
		
		// 중복 확인을 위한 SELECT COUNT문 활용
		$checkQuery = "SELECT COUNT(*) FROM member WHERE nuid = '$nuid'";
		$result = mysqli_query($mysqli, $checkQuery);
		$count = mysqli_fetch_array($result)[0];
		if ($count > 0) {
			// 이미 등록된 카드인 경우 처리
			echo "이미 등록된 카드입니다.";
		} else {
			// 새로운 카드 등록
			$insertQuery = "INSERT INTO member (nuid, enroll) VALUES ('$nuid','$enroll')";
			mysqli_query($mysqli, $insertQuery);
			echo "카드가 성공적으로 등록되었습니다.";
		}
	}
	else{
		echo "MySQL could not be connected";
		}

	mysqli_close($mysqli);
?>


