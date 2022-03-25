<template>
         
  <b-modal
    id="user-import-modal_checkrecord"
    ref="user-import-modal_checkrecord"
    hide-header
     no-close-on-backdrop
  
  >
            <div style="text-align:center; margin:5px; padding: 10px;">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/alert-circle.svg" style="justify-self: center;"/>
             </span>
            </div>
           
        <div>

           
        <p style="text-align:center;font-family: Nunito;font-style: normal;font-weight: bold;font-size: 20px;line-height: 20px;color:red">Chú ý: Đã tồn tại bộ khảo sát này !</p>
        <p style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 17px;line-height: 20px; color:red">{{CheckNote}}</p>    

        <ul>       
        <li><p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 18px;line-height: 20px; ">Bệnh Nhân: {{staff_list[0].user_name}}</p></li>
        <li><p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 18px;line-height: 20px; ">Mã Bệnh Nhân: {{staff_list[0].user_code}}</p></li>
         <li><p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 18px;line-height: 20px; ">Bộ Khảo Sát: {{staff_list[0].survey_name}}</p></li>
        <li><p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 18px;line-height: 20px; ">Mã Khảo Sát: {{staff_list[0].survey_code}}</p></li>
        <li><p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 18px;line-height: 20px;color:blue ">Trạng thái: {{CheckStatus}}</p></li>
        </ul>
        <p style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 17px;line-height: 20px; color:red">{{CheckContent}}</p>    

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
          :disabled="isSelectFile"
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
//import axios from 'axios'
export default {
  props:{
  staff_list:{
    type: Array,
    default: ()=>[],
  },
  survey_code:{
      type: String,
  }
  },
  name: 'Modal',
 
  computed: {
  
   CheckStatus()
  {
   if(this.state_surveyresult.length>=1&&this.state_surveyresult[0].survey_result_id!==null)
   {
    this.SelectFile();
    return "Dữ liệu này đã được xử lý";
 
   }
    else
    {
    return "Dữ liệu này chưa được xử lý";
    }
  },

   CheckContent()
  {
   if(this.state_surveyresult.length>=1&&this.state_surveyresult[0].survey_result_id!==null)
   {
    
    return " Bạn không thể chỉnh sửa bộ khảo sát này ";
 
   }
    else
    {
    return " Bạn có muốn cập nhập lại bộ khảo sát này ? ";
    }
  },

  CheckNote()
  {
   if(this.state_surveyresult.length>=1&&this.state_surveyresult[0].survey_result_id!==null)
   {
    
    return ;
 
   }
    else
    {
    return "( Tất cả những bản ghi cũ của khảo sát này sẽ bị xóa ! )";
    }
  }
    
  },
  watch: {},
  created()
  {
   this.CheckStatus();
   this.$root.$refs.mCK = this
  },
  data() {
    return {
      isMounted: false,
      loading: false,
      isSelectFile: false,
      form: {},
      validationState: {},
      error: {},
      checkaccount:[],
      state_surveyresult: [],
      
    };
    
  },
  mounted()
  {
    this.loadData();
     this.elimited();
    //  console.log(this.staff_list[0].user_code,this.staff_list[0].survey_code)
  },
  methods: {
    
  goback() {
      this.$bvModal.hide('user-import-modal_checkrecord');
    },
 
     elimited: function()
   {  
    
    return this.staff_list.filter((item, pos, self) => self.findIndex(v => v.user_code === item.user_code) === pos);
   },
  
   async AddSurveyDetails()
 {
   
   
    // get survey_id
   const survey_id = await  this.$api.get('surveyimport/only_id',{           
        params:{user_code:this.staff_list[0].user_code ,
                survey_code:this.staff_list[0].survey_code} 
    })
     
              await  this.$api.delete('surveyimportdetails',{
        params:{survey_id:survey_id[0].id}
    })  // delete old data if exist 

 //   console.log(survey_id[0].id,this.staff_list[0].user_code,this.staff_list[0].survey_code)
 
    for(let k=0;k<Number(this.staff_list.length);k++)     // add new data 
     {
      await  this.$api.post('SurveyImportDetails',{headers: {'Content-Type': 'application/json'}}, {
       params: {
       survey_id : survey_id[0].id,
       category_code : this.staff_list[k].category_code,
       category: this.staff_list[k].category,
       sub_category_code: this.staff_list[k].sub_category_code,
       sub_category:this.staff_list[k].sub_category,
       question_code:this.staff_list[k].question_code,
       question_number:this.staff_list[k].question_number,
       question_answer:this.staff_list[k].question_answer,
       question_result:0,
      }
        },
      )}
 
   
 
 },
 

    async handleClick(){
      
         this.$root.$refs.A.SelectFile();
      this.$store.commit('context/setLoading', true);
   // await this.addUser().then( this.AddSurvey()).then(this.goback()) ---------------1 user
    await this.AddSurveyDetails().then(this.goback())
        .catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        }).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })
        .finally(() => {
          this.$store.commit('context/setLoading', false);
           this.$router.push({
        name: 'user_import_list',
         method:{
          // staff_list : data
          },
        params: {
          
         staff_list : this.staff_list
        },
          })
        
            
          
        });
   
    
     
    },
  async loadData() {
      
   
 const survey_id = await  this.$api.get('surveyimport/only_id',{           
        params:{user_code:this.staff_list[0].user_code ,
                survey_code:this.staff_list[0].survey_code} 
    })

  await  this.$api.get('SurveyImport/survey_id_result', {
          params: { id: survey_id[0].id},
          
        }).then( data  => {     
       this.state_surveyresult = data
        
        }).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })  
        console.log(this.state_surveyresult[0].survey_result_id)
    },

  SelectFile()
  {
     this.isSelectFile=true;
  } 

  },
 
};
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
