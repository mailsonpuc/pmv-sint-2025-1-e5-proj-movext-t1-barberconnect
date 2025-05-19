import React, { useState } from 'react';
import {
  View,
  TextInput,
  StyleSheet,
  ImageBackground,
  TouchableOpacity,
  Text,
  ScrollView,
  Alert,
} from 'react-native';
import { useNavigation } from '@react-navigation/native';

export default function Register() {
  const navigation = useNavigation();

  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [birthdate, setBirthdate] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('cliente');

  const handleRegister = async () => {
    try {
      const response = await fetch('https://SEU_BACKEND_URL/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          username,
          email,
          phone,
          birthdate,
          password,
          role,
        }),
      });

      const data = await response.json();

      if (data.success) {
        Alert.alert('Cadastro realizado com sucesso!');
        navigation.navigate('Home');
      } else {
        Alert.alert('Erro', data.message || 'Erro ao realizar cadastro.');
      }
    } catch (error) {
      console.error('Erro no cadastro:', error);
      Alert.alert('Erro', 'Não foi possível conectar ao servidor.');
    }
  };

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
      resizeMode="cover"
    >
      <ScrollView contentContainerStyle={styles.container} keyboardShouldPersistTaps="handled">
        <TextInput
          placeholder="NOME DE USUÁRIO"
          style={styles.input}
          placeholderTextColor="#fff"
          value={username}
          onChangeText={setUsername}
        />
        <TextInput
          placeholder="E-MAIL"
          style={styles.input}
          placeholderTextColor="#fff"
          keyboardType="email-address"
          value={email}
          onChangeText={setEmail}
        />
        <TextInput
          placeholder="CELULAR"
          style={styles.input}
          placeholderTextColor="#fff"
          keyboardType="phone-pad"
          value={phone}
          onChangeText={setPhone}
        />
        <TextInput
          placeholder="DATA DE NASCIMENTO"
          style={styles.input}
          placeholderTextColor="#fff"
          value={birthdate}
          onChangeText={setBirthdate}
        />
        <TextInput
          placeholder="SENHA"
          style={styles.input}
          placeholderTextColor="#fff"
          secureTextEntry
          value={password}
          onChangeText={setPassword}
        />

        <View style={styles.roleContainer}>
          <TouchableOpacity
            style={[styles.roleButton, role === 'cliente' && styles.selectedRole]}
            onPress={() => setRole('cliente')}
          >
            <Text style={styles.roleText}>Cliente</Text>
          </TouchableOpacity>
          <TouchableOpacity
            style={[styles.roleButton, role === 'barbeiro' && styles.selectedRole]}
            onPress={() => setRole('barbeiro')}
          >
            <Text style={styles.roleText}>Barbeiro</Text>
          </TouchableOpacity>
        </View>

        <TouchableOpacity style={styles.registerButton} onPress={handleRegister}>
          <Text style={styles.registerText}>CADASTRE-SE</Text>
        </TouchableOpacity>
      </ScrollView>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  container: {
    paddingHorizontal: 20,
    paddingTop: 260,
    paddingBottom: 30,
    alignItems: 'center',
  },
  input: {
    backgroundColor: 'rgba(255, 255, 255, 0.2)',
    color: '#fff',
    height: 50,
    width: '100%',
    borderRadius: 25,
    paddingHorizontal: 20,
    marginVertical: 8,
  },
  roleContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 10,
    width: '100%',
  },
  roleButton: {
    flex: 1,
    backgroundColor: '#444',
    marginHorizontal: 5,
    borderRadius: 25,
    paddingVertical: 10,
    alignItems: 'center',
  },
  selectedRole: {
    backgroundColor: '#888',
  },
  roleText: {
    color: '#fff',
    fontWeight: 'bold',
  },
  registerButton: {
    backgroundColor: '#666',
    height: 50,
    width: '100%',
    borderRadius: 25,
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 20,
  },
  registerText: {
    color: '#fff',
    fontWeight: 'bold',
  },
});
