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
    };
   
  },
  
  methods: {    
  async  addUser() {

      for(let i=0;i<=Number(this.staff_list.length);i++)
      {
        await this.$api.post('accountimport', {headers: {'Content-Type': 'application/json'}}, {
        params: {
            
          user_name: this.staff_list[i].user_name,
          user_code: this.staff_list[i].user_code,
          user_gender: this.staff_list[i].user_gender,
          user_yearofbirth: this.staff_list[i].user_yearofbirth,
          user_career: this.staff_list[i].user_career,
          user_phone: this.staff_list[i].user_phone,
          user_hoobit: this.staff_list[i].user_hoobit,
          user_address: this.staff_list[i].user_address,
          user_province: this.staff_list[i].user_province,
          story_success: this.staff_list[i].story_success,
          user_typeofsick: this.staff_list[i].user_typeofsick,
          year_foundout:this.staff_list[i].year_foundout,
           
        },
         
        })
        
           await  this.$api.get('accountimport/id').then(this.AddSurvey());

        ;;
   //     console.log()
  }




   },

   async AddSurvey ()
 {
   
    const data = await this.$api.get('accountimport/id')
      
   
  
    for(let j=0;j<=Number(this.staff_list.length);j++)
     {
   const survey_day = new Date(this.staff_list[j].survey_day).toISOString().slice(0, 10);
   const import_day = new Date(this.staff_list[j].import_day).toISOString().slice(0, 10);
 
  await  this.$api.post('surveyimport',{headers: {'Content-Type': 'application/json'}}, {
  
       params: {    

      user_id : data[j].id,
      course_goal: this.staff_list[j].course_goal,
      course_action:this.staff_list[j].course_action,
      course_final_rate:this.staff_list[j].course_final_rate,
      participation_package:this.staff_list[j].participation_package,
      survey_type_code:this.staff_list[j].survey_type_code,
      survey_type:this.staff_list[j].survey_type,
      survey_code:this.staff_list[j].survey_code,
      survey_name:this.staff_list[j].survey_name,
      import_day:  import_day,
      survey_day: survey_day
        },
   
      
      }).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })
    



     
     }
 
 },
   
 

    goback() {
      this.$bvModal.hide('user-import-modal');
    },
    openModalSuccess: function()
    {
        this.$root.$refs.A.clickshow();
    },

    async handleClick(){
      this.$store.commit('context/setLoading', true);
    await this.addUser().then(this.goback())
        .finally(() => {
          this.$store.commit('context/setLoading', false);
             this.openModalSuccess();
        });
   
    
     
    },
    
  },
  mounted(){

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