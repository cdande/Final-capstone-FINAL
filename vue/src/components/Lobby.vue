<template>
  <div class="container">
    <h1>Welcome To Your Game! Please Select Your Players!</h1>
    <table id="tblUsers">
      <thead>
        <tr>
          <th>&nbsp;</th>
          <th>Username |</th>
          <th>Select Character |</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <input type="checkbox" id="selectAll" v-bind="selectedUsers" />
          </td>

          <td>&nbsp;</td>
        </tr>
        <tr
          v-for="user in users"
          v-bind:key="user.id"
          v-bind:class="{ deactivated: user.status === 'Inactive' }"
        >
          <td>
            <input
              type="checkbox"
              class="checkbox"
              v-bind:id="user.id"
              v-bind:value="user.id"
              v-bind="selectedUsers"
              v-on:click="addtoCheckBoxArray(user)"
            />
          </td>
          <td class="">{{ user.username }}</td>
          <td class="">{{ user.selectCharacter }}</td>
        </tr>
      </tbody>
    </table>

    <div class="all-actions">
      <button v-bind:disabled="disabled" v-on:click="deleteSelelected">
        Delete Users
      </button>
    </div>

    <button href="#" v-on:click.prevent="showForm = !showForm">
      Add New User
    </button>
    <button @click="$router.push('gameboard')" id="button">Start Game!</button>
    <form
      id="frmAddNewUser"
      v-on:submit.prevent="addNewUser"
      v-show="showForm === true"
    >
      <div class="field">
        <label for="userName">Username:</label>
        <input
          type="text"
          required
          name="userName"
          v-model="newUser.username"
        />
      </div>
      <div class="field">
        <label for="selectCharacter"> Select Character:</label>
        <select required v-model="newUser.selectCharacter">
          <option value="bull" v-bind:disabled="isCharacterSelected('bull')">
            Bull
          </option>
          <option value="bear" v-bind:disabled="isCharacterSelected('bear')">
            Bear
          </option>
          <option value="shark" v-bind:disabled="isCharacterSelected('shark')">
            Shark
          </option>
          <option value="lion" v-bind:disabled="isCharacterSelected('lion')">
            Lion
          </option>
          <option value="eagle" v-bind:disabled="isCharacterSelected('eagle')">
            Eagle
          </option>
          <option value="tiger" v-bind:disabled="isCharacterSelected('tiger')">
            Tiger
          </option>
        </select>
      </div>

      <button type="submit" class="btn save" v-on:click="newUser">
        Save Player
      </button>
    </form>
  </div>
</template>

<script>
export default {
  name: "user-list",
  data() {
    return {
      nextUserId: 7,
      showForm: false,
      selectedUsers: [],
      newUser: {
        id: null,
        username: "",
        selectCharacter: "",
        status: "Active",
      },
      users: [
        // The person loggin in should be automagically number one in the lobby without us adding
      ],
    };
  },
  methods: {
    getNextUserId() {
      // sql api call needed for the id
      return this.nextUserId++;
    },
    addNewUser() {
      this.$store.commit("ADD_USER", this.newUser);
      this.newUser.id = this.getNextUserId();
      this.users.unshift(this.newUser);
      this.newUser = {
        id: null,
        username: "",
        selectCharacter: "",
        status: "Active",
      };
    },

    addtoCheckBoxArray(user) {
      if (this.selectedUsers.includes(user)) {
        let index = this.selectedUsers.indexOf(user);
        this.selectedUsers.splice(index, 1);
      } else {
        this.selectedUsers.push(user);
      }
    },
    activateSelectedUsers() {
      this.selectedUsers.forEach((user) => {
        user.status = "Active";
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    deactivateAll() {
      this.selectedUsers.forEach((user) => {
        user.status = "Inactive";
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    deleteSelelected() {
      this.selectedUsers.forEach((user) => {
        this.users.pop(user);
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    isCharacterSelected(character) {
      return this.users.some((user) => user.selectCharacter === character);
    },
  },
};
</script>

<style scoped>
table {
  margin-top: 20px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  margin-bottom: 20px;
}
h1 {
  text-align: center;
}
th {
  text-transform: uppercase;
}
td {
  padding: 10px;
}
tr.deactivated {
  color: red;
}
input,
select {
  font-size: 16px;
}

form {
  margin: 20px;
  width: 350px;
}
.field {
  padding: 10px 0px;
}
label {
  width: 140px;
  display: inline-block;
}
button {
  margin-right: 5px;
}
.all-actions {
  margin-bottom: 40px;
}
.btn.save {
  margin: 20px;
  float: right;
}
</style>