const proceedButton=document.querySelector('#enterEmailB');
const emailTextField=document.querySelector('#emailTF');
const checkVerificationButton=document.querySelector('#checkVerificationB');
const verificationTextField=document.querySelector('#verificationTextField');
const counterObject=document.querySelector('#counter');

verificationTextField.style.visibility="hidden";
checkVerificationButton.style.visibility="hidden";
counterObject.style.visibility="hidden";

function AddEmail(email){

    const body ={
        email:email
    }
    fetch('http://localhost:5026/api/Users/RegisterEmail',{
        method: 'POST',
        body:JSON.stringify(body),
        headers:{
            "content-type":"application/Json"
        }

    })
    .then(data=>data.json())
    .then(Response=>console.log(Response))
}


function CheckVerification(email,verificationCode) {
    const body={
        verificationCode:verificationCode
    }
    fetch('http://localhost:5026/api/Users/CheckVerification',{
        method: 'POST',
        body:JSON.stringify(body),
        headers:{
            "content-type":"application/Json"
        }
    })
    .then(Response=>console.log(Response))
  }


function VerificationFailChangeStates() {
    verificationTextField.style.visibility="hidden";
    checkVerificationButton.style.visibility="hidden";
    counterObject.style.visibility="hidden";

    proceedButton.style.visibility="visible";
    emailTextField.style.visibility="visible";
  }


function VerificationTimeOut(email){
    const body={
        email:email
    }
    fetch('http://localhost:5026/api/Users/VerificationTimeOut',{
        method:'POST',
        body:JSON.stringify(body),
        headers:{"content-type":"application/Json"}
    })
  }

proceedButton.addEventListener('click',function(){
    var timeleft = 15;
    counterObject.style.color="black";
    AddEmail(emailTextField.value);
    verificationTextField.style.visibility="visible";
    checkVerificationButton.style.visibility="visible";
    counterObject.style.visibility="visible";

    proceedButton.style.visibility="hidden";
    emailTextField.style.visibility="hidden";

    window.timer = setInterval(function function1(){
    counterObject.innerHTML = timeleft + 
    "&nbsp"+"seconds remaining";

    timeleft -= 1;
    if(timeleft <= 0){
        counterObject.innerHTML = "Retry by entering the email again"
        counterObject.style.color="red";
    }
    if(timeleft<=-4){
        VerificationTimeOut(emailTextField.value);
        VerificationFailChangeStates();
    }
    }, 1000);

    console.log(counter);
});

checkVerificationButton.addEventListener('click',function(){
    VerificationFailChangeStates();
    CheckVerification(emailTextField.value, verificationTextField.value);


})
