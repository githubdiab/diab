<template>
        
 
  <b-modal
    id="user-import-modal"
    ref="user-import-modal"
    hide-header
   
    no-stacking
  >
            <div style="text-align:center;">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/sss.svg" style="justify-self: center;"/>
             </span>
            </div>
           
         <div  style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;">

          
         {{this.staff_list.length+"/"+staff_list.length}} bản ghi  thỏa mãn điều kiện. Bạn có muốn tiếp tục Import dữ liệu?
         
          </div>
    <template #modal-footer style="text-align:center">
        <!--<b-button class="btn btn-secondary" href="#" tabindex="0">
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/power.svg" />
          </span>
          Hủy
        </b-button> -->
      
          

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="goback()"
          tabindex="0"
          style="width:90px"
        >
        
          Huỷ
        
        </b-button>

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="handleClick()"
          tabindex="0"
      
        >
        <span class="svg-icon">
            <inline-svg src="/media/svg/import/tick.svg" />
          </span>
         Đồng ý
          
        </b-button>

        
      
      
    </template>
  </b-modal>
 

</template>

<script>

//import $ from 'jquery' ;

//import ModalSuccess from './messageSuccess.vue';
//import axios from 'axios'
//import moment from 'vue-moment'
export default {
  name: 'Modal',   
 // components:{ModalSuccess},
 props: {
    staff_list: {
      type: Array,
      default: () => [],
    },
  },
  computed:{
    

    
  },
  data() {
    return {
      // user 
      user_name: '',
      user_code:'',
      user_gender:'',
      user_yearofbirth:'',
      user_career:'',
      user_phone:'',
      user_hoobit:'',
      user_address:'',
      user_province:'',
      story_success:'',
      user_typeofsick:'',
      year_foundout:'',

// survey
      course_goal:'',
      course_action:'',
      course_final_rate:'',
      participation_package:'',
      survey_type_code:'',
      survey_type:'',
      survey_code:'',
      survey_name:'',
      survey_day:"",
      import_day:"",
      user_id:'',
   
   //survey details 
       survey_id:'',
       category_code :'',
       category:'',
       sub_category_code:'',
       sub_category:'',
       question_code:'',
       question_number:'',
       question_answer:'',
       question_result:'',
     
     data:[],
     checkaccount:[],
    checksurvey:[],
    };
   
  },
  
  methods: {    
  async  addUser() {

      for(let i=0;i<Number(this.elimited().length);i++)
      {
        await this.$api.post('accountimport', {headers: {'Content-Type': 'application/json'}}, {
        params: {
            
          user_name: this.elimited()[i].user_name,
          user_code: this.elimited()[i].user_code,
          user_gender: this.elimited()[i].user_gender,
          user_yearofbirth: this.elimited()[i].user_yearofbirth,
          user_career: this.elimited()[i].user_career,
          user_phone: this.elimited()[i].user_phone,
          user_hoobit: this.elimited()[i].user_hoobit,
          user_address: this.elimited()[i].user_address,
          user_province: this.elimited()[i].user_province,
          story_success: this.elimited()[i].story_success,
          user_typeofsick: this.elimited()[i].user_typeofsick,
          year_foundout:this.elimited()[i].year_foundout,
           
        },
         
        })
        
        ;;

  }




   },

   async AddSurvey ()
 {

   for(let a=0;a<=Number(this.elimited().length);a++)
     {

     await  this.$api.get('accountimport/id').then(res=>{          //get all id 
       this.checkaccount = res     
     });
     
     }
       await  this.$api.get('surveyimport/id').then(res=>{          //get survey_code , user_id
       this.checksurvey = res});
  // console.log(this.checksurvey)
   
  for(let n=0;n< this.checkaccount.length;n++)
    for(let j=0;j<Number(this.elimited().length);j++)
     {
  
   const survey_day = new Date(this.elimited()[j].survey_day).toISOString();
  // const import_day = new Date(this.elimited()[j].import_day).toISOString();

  //let toTimestamp = strDate => Date.parse(strDate)

  if( Number(this.checkaccount[n].user_code)===Number(this.elimited()[j].user_code))
  {
    const a = this.checksurvey.filter((item)=> item.user_id===this.checkaccount[n].id )
    const b = this.checksurvey.filter((item)=> item.survey_code===this.elimited()[j].survey_code)
   
   if(a.length>0 && b.length>0)      // check duplicate survey_imports
    { 
     //console.log(this.checksurvey[j].survey_code ,this.checksurvey[j].user_id,this.checkaccount[n].id)
      // console.log(this.checksurvey.filter((item)=> item.user_id===this.checkaccount[n].id ))
      // console.log(this.checksurvey.filter((item)=> item.survey_code===this.elimited()[j].survey_code))

            this.openModalCheckRecord();
          
  }
 else
 {
   var survey_type_code_KIND = 'Khác'

   if(this.elimited()[j].survey_code.slice(0,4)==='KSDV')
   {
       survey_type_code_KIND = 'KSDV'
   }
   if(this.elimited()[j].survey_code.slice(0,4)==='KSDR')
   {
        survey_type_code_KIND = 'KSDR'
   }
   
  await  this.$api.post('surveyimport',{headers: {'Content-Type': 'application/json'}}, {
  
       params: {    

      user_id :  this.checkaccount[n].id,
      course_goal: this.elimited()[j].course_goal,
      course_action:this.elimited()[j].course_action,
      course_final_rate:this.elimited()[j].course_final_rate,
      participation_package:this.elimited()[j].participation_package,   
      survey_type:this.elimited()[j].survey_type,
      survey_code:this.elimited()[j].survey_code,
      survey_type_code:survey_type_code_KIND,
    //  survey_type_code:this.elimited()[j].survey_code.slice(0,4),
    //   survey_type_code: this.elimited()[j].survey_type_code,
      survey_name:this.elimited()[j].survey_name,
    //  import_day:  import_day.slice(0, 10),
      survey_day: survey_day.slice(0, 10)
        },
   
      
      })
      .catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })   
     }
  }
     }
 },
     elimited: function()
   {  
    
    return this.staff_list.filter((item, pos, self) => self.findIndex(v => v.user_code === item.user_code) === pos);
  },
 

   
     openModalCheckRecord: function()
    {
        this.$root.$refs.A.clickshow_checkrecord();
       this.CloseModalSuccess();
      
        
    },

    CloseModalSuccess: function()
    {
        this.$root.$refs.A.clickhide();
        
    },

    openModalSuccess: function()
    {
        this.$root.$refs.A.clickshow();
        
    },
    goback()
    {
      this.$bvModal.hide('user-import-modal')
    //  this.$root.$refs.A.NotselectFile();
    },

    async handleClick(){
         this.$root.$refs.A.SelectFile();
      this.$store.commit('context/setLoading', true);
   // await this.addUser().then( this.AddSurvey()).then(this.goback()) ---------------1 user
    await this.addUser().then(this.AddSurvey()).then(this.goback())
        .finally(() => {
          this.$store.commit('context/setLoading', false);
             this.openModalSuccess();
          
        });
   
    
     
    },
    
  },
  mounted(){
      this.elimited();
  }
}
</script>

<style lang="scss">
.modal-dialog {
  height: 60%;
  width: 600px;
  display: flex;
  align-items: center;
}

.modal-content {
  margin: 0 auto;
}
.modal-footer{
  justify-content: center;
  //text-align: center;
}
.svg-tick{
    justify-content: center;
}


</style>
}